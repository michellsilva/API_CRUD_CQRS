using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;

namespace AvaliacaoFC.Nucleo.Infra.Servicos
{
    public class GeradorEmail : IGeradorEmail
    {
        public string Provedor { get; private set; }
        public int Porta { get; private set; }
        public string EmailRemetente { get; private set; }
        public string NomeUsuario { get; private set; }
        public string Senha { get; private set; }

        public GeradorEmail(string provedor, int porta, string emailRemetente, string nomeUsuario, string senha)
        {
            Provedor = provedor;
            Porta = porta;
            EmailRemetente = emailRemetente;
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }

        public void Enviar(IEnumerable<string> emails, string assunto, string corpo, IEnumerable<string>? anexos)
        {
            var message = MontarMessage(emails, assunto, corpo, anexos);

            EnviarPorSmtp(message);
        }

        private MailMessage MontarMessage(IEnumerable<string> emails, string assunto, string corpo, IEnumerable<string>? anexos)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(EmailRemetente);

                foreach (var email in emails)
                {
                    if (ValidarEmail(email))
                    {
                        mail.To.Add(email);
                    }
                }

                mail.Subject = assunto;
                mail.Body = corpo;
                mail.IsBodyHtml = true;

                if (anexos != null)
                {
                    foreach (var file in anexos)
                    {
                        var data = new Attachment(file, MediaTypeNames.Application.Octet);
                        ContentDisposition disposition = data.ContentDisposition!;
                        disposition.CreationDate = File.GetCreationTime(file);
                        disposition.ModificationDate = File.GetLastWriteTime(file);
                        disposition.ReadDate = File.GetLastAccessTime(file);

                        mail.Attachments.Add(data);
                    }
                }
           

                return mail;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private bool ValidarEmail(string email)
        {
            Regex expresssao = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            if (expresssao.IsMatch(email))
                return true;

            return false;
        }

        private void EnviarPorSmtp(MailMessage menssagem)
        {
            SmtpClient smtpClient = new SmtpClient(Provedor, Porta);
            smtpClient.Credentials = new NetworkCredential(NomeUsuario, Senha);
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 50000;

            smtpClient.Send(menssagem);

            smtpClient.Dispose();
        }

    }
}
