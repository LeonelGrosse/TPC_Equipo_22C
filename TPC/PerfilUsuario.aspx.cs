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
        protected void Page_Load(object sender, EventArgs e)
        {
            //si no es nulo
            

            if (Session["Email"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else {
                string email = (Session["Email"].ToString());
                CargarDatosUsuario(email);
            }
            //sino cargar login
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