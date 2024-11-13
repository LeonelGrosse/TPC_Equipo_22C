using dominio;
using negocio;
using accesorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

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
        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btn_modificar.Visible = false;
            btn_confirmar.Visible = true;
            btn_cancelar.Visible = true;
        }

        protected void btn_confirmar_Click(object sender, EventArgs e)
        {
            AgregarValidacionesInputs();
            Page.Validate();

            if (!Page.IsValid)
                return;

            if (txtNombre.Text != Seguridad.UsuarioLogueado.Nombre)
                usuarioNegocio.ModificarEscalar("Nombre", Seguridad.UsuarioLogueado.IdUsuario, txtNombre.Text);

            if (txtApellido.Text != Seguridad.UsuarioLogueado.Apellido)
                usuarioNegocio.ModificarEscalar("Apellido", Seguridad.UsuarioLogueado.IdUsuario, txtApellido.Text);

            if (txtEmail.Text != Seguridad.UsuarioLogueado.CorreoElectronico)
                usuarioNegocio.ModificarEscalar("CorreoElectronico", Seguridad.UsuarioLogueado.IdUsuario, txtEmail.Text);

            if (txtPassword.Text != Seguridad.UsuarioLogueado.Contrasenia)
                usuarioNegocio.ModificarEscalar("Contrasena", Seguridad.UsuarioLogueado.IdUsuario, txtPassword.Text);
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            HabilitarCampos(true);
            btn_modificar.Visible = true;
            btn_confirmar.Visible = false;
            btn_cancelar.Visible = false;
        }

        private void HabilitarCampos(bool estado = false)
        {
            txtNombre.ReadOnly = estado;
            txtApellido.ReadOnly = estado;
            txtEmail.ReadOnly = estado;
            txtPassword.ReadOnly = estado;
        }

        private void AgregarValidacionesInputs()
        {
            Validator.CampoVacio("txtNombre", "*El campo requiere un valor.", containerControlNombre);
            Validator.CampoVacio("txtApellido", "*El campo requiere un valor.", containerControlApellido);
            Validator.CampoVacio("txtEmail", "*El campo requiere un valor.", containerControlEmail);
            Validator.CampoVacio("txtPassword", "*El campo requiere un valor.", containerControlPassword);
            Validator.ExpresionRegular("txtNombre", "*Solo letras.", containerControlNombre, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]{2,254}$");
            Validator.ExpresionRegular("txtApellido", "*Solo letras.", containerControlApellido, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ ]{2,254}$");
            Validator.ExpresionRegular("txtEmail", "*Formato de email incorrecto. Ejemplo: usuario@proveedor.com.", containerControlEmail, @"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$");
            Validator.ExpresionRegular("txtPassword", "*Al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial.", containerControlPassword, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_])[A-Za-z\d\W_]{8,}$");
        }
    }
}