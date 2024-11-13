using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        private UsuarioNegocio usuarioNegocio;

        public PerfilUsuario()
        {
            usuarioNegocio = new UsuarioNegocio();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.UsuarioLogueado == null)
                Response.Redirect("Default.aspx");

            if (!IsPostBack)
                CargarDatosUsuario();
        }

        public void CargarDatosUsuario()
        {
            Usuario usuario = Seguridad.UsuarioLogueado;

            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtDni.Text = usuario.Dni;
            txtEmail.Text = usuario.CorreoElectronico;
            txtFechaNacimiento.Text = usuario.FechaNacimiento.ToString("d"); // Fecha corta
            txtPassword.Text = usuario.Contrasenia;
            if (usuario.Imagen.ID != 0)
                UrlImagen.ImageUrl = usuario.Imagen.URL;
        }
        }

        public void CargarDatosUsuario(string email)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = usuarioNegocio.cargar(email);

            txtNombreUsuario.Text = " " + usuario.Nombre + " " +usuario.Apellido;
            txtDniUsuario.Text = " " + usuario.Dni;
            txtEmailUsuario.Text = " " + usuario.CorreoElectronico;
            txtFechaNacimiento.Text = " " + usuario.FechaNacimiento.ToString("d"); // Fecha corta
            txtRolUsuario.Text = " " + usuario.Rol.Descripcion;
            txtPasswordUsuario.Text = " " + usuario.Contrasenia;
        }
    }
}