using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutenticacaoAutorizacao.Models;
using System.Security.Claims;
using System.Security.Cryptography;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutenticacaoAutorizacao.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AutenticacaoAutorizacao.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthContext _context;

        public AuthController(AuthContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest login)
        {
            var usuario = await _context
                .Usuarios
                .FirstOrDefaultAsync(u => 
                        u.Username == login.Username && 
                        u.Password == login.Password);

            if (usuario == null)
            {
                return NotFound("Usuário ou senha incorreto.");
            }

            var token = CreateToken(usuario);

            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Usuario usuario) 
        {
            CreatePasswordHash(usuario.Password,
                                out byte[] passwordhash,
                                out byte[] passwordkey);

            usuario.PasswordHash = passwordhash;
            usuario.PasswordKey = passwordkey;

            _context.Usuarios.Add(usuario);

            await _context.SaveChangesAsync();

            return Ok(usuario);
        }

        private void CreatePasswordHash(string password,
                                out byte[] passwordhash,
                                out byte[] passwordkey)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordkey = hmac.Key;
                passwordhash = hmac
                    .ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private string CreateToken(Usuario usuario)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.NameIdentifier, usuario.Username),
                new Claim(ClaimTypes.Role, usuario.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(JwtServices.SecrectKey));

            var creds = new SigningCredentials(key,
                        SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                 claims: claims,
                 signingCredentials: creds,
                 expires: DateTime.Now.AddMinutes(30)
                );

            var jwt = new JwtSecurityTokenHandler()
                            .WriteToken(token);

            return jwt;
        }
    }
}
