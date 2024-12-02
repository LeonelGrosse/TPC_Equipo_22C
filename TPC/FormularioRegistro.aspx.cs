using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using accesorio;
using System.Data.SqlClient;

namespace TPC
{
    public partial class FormularioRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            if (string.IsNullOrWhiteSpace(txtNombre.Text) || !Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z]+$"))
            {
                lblAvisoNombre.Text = "Por favor, ingrese un nombre válido.";
                lblAvisoNombre.ForeColor = System.Drawing.Color.Red;
                lblAvisoNombre.Visible = true;
                return;
            }
            else { lblAvisoNombre.Visible = false; usuario.Nombre = txtNombre.Text; }


            if (string.IsNullOrWhiteSpace(txtApellido.Text) || !Regex.IsMatch(txtApellido.Text, @"^[a-zA-Z]+$"))
            {
                lblAvisoApellido.Text = "Por favor, ingrese un apellido válido.";
                lblAvisoApellido.ForeColor = System.Drawing.Color.Red;
                lblAvisoApellido.Visible = true;
                return;
            }
            else { lblAvisoApellido.Visible = false; usuario.Apellido = txtApellido.Text; }


            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblAvisoEmail.Text = "Por favor, ingrese un Email válido.";
                lblAvisoEmail.ForeColor = System.Drawing.Color.Red;
                lblAvisoEmail.Visible = true;
                return;
            }
            else { lblAvisoEmail.Visible = false; usuario.CorreoElectronico = txtEmail.Text; }

            //check dni para corroborar que no se repita
            int dni;
            bool isValid = int.TryParse(txtDNI.Text, out dni);

            if (!isValid)
            {
                lblAvisoDNI.Text = "Por favor, ingrese un número de DNI válido";
                lblAvisoDNI.ForeColor = System.Drawing.Color.Red;
                lblAvisoDNI.Visible = true;
                return;
            }
            else
            {
                bool DniOk = negocio.checkUsuario(dni);
                if (DniOk == true)
                {
                    lblAvisoDNI.Visible = false; usuario.Dni = txtDNI.Text;
                }
            }

            if (string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) || !DateTime.TryParse(txtFechaNacimiento.Text, out DateTime fecha))
            {
                lblAvisoFechaNacimiento.Text = "Por favor, ingrese una fecha válida.";
                lblAvisoFechaNacimiento.ForeColor = System.Drawing.Color.Red;
                lblAvisoFechaNacimiento.Visible = true;
                return;
            }
            else {lblAvisoFechaNacimiento.Visible = false; usuario.FechaNacimiento = fecha;}

            if (string.IsNullOrWhiteSpace(txtContraseniaRegistro.Text) ||
                txtContraseniaRegistro.Text.Length < 8 ||
                !Regex.IsMatch(txtContraseniaRegistro.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-]).+$")){

                lblAvisoContrasenias.Text = "La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial.";
                lblAvisoContrasenias.ForeColor = System.Drawing.Color.Red;
                lblAvisoContrasenias.Visible = true;
                return;
            }
            else 
            {
                lblAvisoContrasenias.Visible = false; 
                usuario.Contrasenia = Encrypt.GetSHA256(txtContraseniaRegistro.Text);
            }

            usuario.Rol.IdRol = 2;

            // se agrega usuario validado (rol de usuario)
            int idActual = negocio.agregar(usuario);

            

            ///CARGAR IMAGEN
            try
            {               
                string ruta = Server.MapPath("./Imagenes/");
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Dni + ".jpg");

                usuario.Imagen.URL = "perfil-" + usuario.Dni + ".jpg";

                negocio.cargarImagen(usuario, idActual);

                

            }
            catch (Exception ex)
            {

                throw ex;
            }

            
            
            Response.Redirect("Login.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
             
    }
}