using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutenticacaoAutorizacao.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> Get(string fileName)
        {
            //var uploadResult = await _context.Uploads.FirstOrDefaultAsync(u => u.StoredFileName.Equals(fileName));

            var path = Path.Combine(_env.ContentRootPath, "uploads/produtos", fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "image/jpeg", Path.GetFileName(path));
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            string nomeArquivoServidor = string.Empty;
            foreach (var file in files)
            {
                nomeArquivoServidor = Path.GetRandomFileName();

                var path = Path.Combine(_env.ContentRootPath, "uploads/produtos", nomeArquivoServidor);

                await using FileStream fs
                    = new(path, FileMode.Create);

                await file.CopyToAsync(fs);

                
            }


            return Ok(nomeArquivoServidor);
        }
    }
}
