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
            CargarDatosUsuario();
        }

        public void CargarDatosUsuario()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Usuario> usuarios = usuarioNegocio.Listar();

            txtNombreUsuario.Text = ($"{usuarios[0].Nombre} , {usuarios[0].Apellido}");
            txtDniUsuario.Text = usuarios[0].Dni;
            txtEmailUsuario.Text = usuarios[0].CorreoElectronico;
            txtFechaNacimiento.Text = usuarios[0].FechaNacimiento.ToString("d"); // Fecha corta
            txtRolUsuario.Text = usuarios[0].Rol.Descripcion;
            txtPasswordUsuario.Text = usuarios[0].Contrasenia;
        }
    }
}