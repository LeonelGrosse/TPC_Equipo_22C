using dominio;
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
            server.Credentials = new NetworkCredential("mmeny112@gmail.com", "zbvl zlch yqkh jxxp");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreoInscripcion(string emailDestino, int idEvento)
        {
            AccesoDatos Datos = new AccesoDatos();
            Evento evento = new Evento();

            try
            {
                Datos.LimpiarComando();
                Datos.setConsulta("SELECT * FROM Evento where IDEvento = @idEvento");
                Datos.setParametro("@IDEVENTO", idEvento);
                Datos.ejecutarLectura();

                if (Datos.Lector.Read())
                    evento.Nombre = (string)Datos.Lector["Nombre"];
                    evento.FechaEvento = (DateTime)Datos.Lector["FechaEvento"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Datos.cerrarConexion();
            }

            email = new MailMessage();
            email.From = new MailAddress("noResponder@BAEventos.com");
            email.To.Add(emailDestino);
            email.Subject = "Inscripcion exitosa a evento";
            email.IsBodyHtml = true;
            email.Body = "<h2>Te inscribiste correctamente a </h2><br><br><h1>"+ evento.Nombre + " el dia " + evento.FechaEvento.ToString("dd/MM/yyyy") +
                "</h1> <br> Ya quedó guardado tu registro. Para mas información ver MIS INSCRIPCIONES en nuestra web <br>Si ya realizaste el pago" +
                " solo tenes que asistir el dia del evento. De lo contrario podes realizarlo en nuestra web o de forma presecial en efectivo.<br>" +
                "Ante cualquier duda comunicate con nuestro staff mediante la pestala de CONTACTO de nuestra web <br> <br>Muchas gracias <br> <br>BAEventos";
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
