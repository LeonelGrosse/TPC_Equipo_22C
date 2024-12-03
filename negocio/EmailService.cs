using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("programationiii@gmail.com", "programacion3");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreoInscripcion(string emailDestino)
        {
            email = new MailMessage();
            email.From = new MailAddress("contacto@BAEventos.com");
            email.To.Add(emailDestino);
            email.Subject = "Inscripcion exitosa a evento";
            email.IsBodyHtml = true;
            email.Body = "<h1>Incripcion exitosa a un evento</h1> <br> Ya quedó guardado tu registro. Si ya realizaste el pago" +
                "solo tenes que asistir el dia del evento. De lo contrario podes realizarlo en nuestra web o de forma presecial en efectivo." +
                "Ante cualquier duda comunicate con nuestro staff mediante la pestala de CONTACTO de nuestra web <br>Muchas gracias <br>BAEventos";
        }

        public void enviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
