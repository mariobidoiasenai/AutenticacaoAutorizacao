using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Crypto.Tls;

namespace AutenticacaoAutorizacao.WebAPI.Services
{
    public class EmailService
    {

        public async Task Send(List<string> destinarios,
                                string assunto,
                                string corpoEmail,
                                string remetente)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(remetente));

            foreach (var item in destinarios)
            {
                email.To.Add(MailboxAddress.Parse(item));
            }

            email.Subject = assunto;

            email.Body = new TextPart() { Text = corpoEmail };

            var smtpHost = "smtp.gmail.com";
            var smtpPort = 465;
            var usuario = "mario.cleber@docente.senai.br";
            var password = "senha";

            var smtp = new SmtpClient();
            await smtp.ConnectAsync(smtpHost, smtpPort,true);

            await smtp.AuthenticateAsync(usuario, password);

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
    }
}
