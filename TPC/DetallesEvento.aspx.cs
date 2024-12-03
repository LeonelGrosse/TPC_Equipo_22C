using accesorio;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Discovery;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class DetallesEvento : System.Web.UI.Page
    {
        EventoNegocio eventoNegocio = new EventoNegocio();
        public Evento evento = new Evento();
        DisciplinaNegocio disciplinaNegocio = new DisciplinaNegocio();
        public List<Disciplina> disciplinas = new List<Disciplina>();
        Usuario usuario = new Usuario();
        EmailService emailService = new EmailService();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.RestringirAcceso(Session["UsuarioActivo"], Roles.Participante) || Session["UsuarioActivo"] == null)
            {
                Response.Redirect("Default.aspx", false);
                return;
            }

            int idEvento = int.Parse(Request.Params["IdEvento"].ToString());
            evento = eventoNegocio.Listar(idEvento)[0];
            if (!IsPostBack)
            {
                CargarDatosEvento();
            }
        }

        public void CargarDatosEvento()
        {
            txtNombre.Text = evento.Nombre;
            txtFecha.Text = evento.FechaEvento.ToString("dd-MM-yyyy");
            txtProvincia.Text = evento.Ubicacion.Ciudad.Provincia.Nombre;
            txtCiudad.Text = evento.Ubicacion.Ciudad.Nombre;
            txtCalle.Text = evento.Ubicacion.Direccion.Calle;
            txtAltura.Text = evento.Ubicacion.Direccion.Altura.ToString();
            txtCosto.Text = ((int)evento.CostoInscripcion).ToString();
            txtCupos.Text = evento.CuposDisponibles.ToString();
            txtEdadMinima.Text = evento.EdadMinima.ToString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int idEvento = int.Parse(Request.Params["IdEvento"].ToString());
            usuario = (Usuario)Session["UsuarioActivo"];
            int idUsuario = usuario.IdUsuario;
            string correo = usuario.CorreoElectronico;

            if(eventoNegocio.SiEstaInscripto(idUsuario, idEvento))
            {
                MostrarMensajeError("Ya esta inscripto.");
                return;
            }

            eventoNegocio.InscribirseEvento(idEvento, idUsuario);
            MostrarMensajeError("Inscripcion exitosa!", true);
            emailService.armarCorreoInscripcion(correo);
            try
            {
                emailService.enviarMail();
            }
            catch (Exception ex)
            {

                Session.Add("error",ex);
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Eventos.aspx", false);
        }

        protected void BtnVolverInicio_Click(object sender, EventArgs e)
        {
            MostrarMensajeError("", false);
            Response.Redirect("Eventos.aspx", false);
        }
        private void MostrarMensajeError(string mensaje, bool visible = true)
        {
            ContainerCard.Visible = visible;
            CardMsj.Text = mensaje;
        }
    }
}