using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            bool LoginOK = negocio.checkLogin(txtUsuario.Text, txtContrasenia.Text);

            if (LoginOK == true)
            {
                Session.Add("Email", txtUsuario.Text);
                Response.Redirect("Default.aspx", false);
            }
            else
            {

                lblAvisoLogin.Text = "El usuario o la contraseña no es válido";
                lblAvisoLogin.ForeColor = System.Drawing.Color.Red;
                lblAvisoLogin.Visible = true;
            }

            
        }

        protected void btnOlvido_Click(object sender, EventArgs e)
        {
            lblRecuEmail.Visible = true;
            lblRecuDNI.Visible = true;
            txtRecuEmail.Visible = true;
            txtRecuDNI.Visible = true;
            btnSiguiente.Visible = true;

            lblAvisoLogin.Visible = false;
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            bool RecuOK = negocio.checkRecuperacion(txtRecuEmail.Text, txtRecuDNI.Text);

            if (RecuOK == true)
            {
                lblNuevaContrasenia.Visible = true;
                lblRepeNuevaContrasenia.Visible = true;
                txtNuevaContrasenia.Visible = true;
                txtRepeNuevaContrasenia.Visible = true;
                btnRecuperar.Visible = true;
                Session.Add("SessionEmail", txtRecuEmail.Text);

                lblAvisoSiguiente.Visible = false;
                
            }
            else
            {

                lblAvisoSiguiente.Text = "El usuario o el DNI no es válido";
                lblAvisoSiguiente.ForeColor = System.Drawing.Color.Red;
                lblAvisoSiguiente.Visible = true;
            }
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            string pass = txtNuevaContrasenia.Text;
            string repePass = txtRepeNuevaContrasenia.Text;
            string email = Session["SessionEmail"].ToString();

            if (string.IsNullOrWhiteSpace(txtNuevaContrasenia.Text) ||
                txtNuevaContrasenia.Text.Length < 8 ||
                !Regex.IsMatch(txtNuevaContrasenia.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-]).+$"))
            {

                lblAvisoRecuperar.Text = "La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial.";
                lblAvisoRecuperar.ForeColor = System.Drawing.Color.Red;
                lblAvisoRecuperar.Visible = true;
                return;
            }
            
            else if (pass == repePass)
            {
                bool recuOk = negocio.RecuperarContrasenia(pass, email);

                if(recuOk == true)
                {
                    lblAvisoLogin.Text = "Contraseña reestablecida. Inicie sesión";
                    lblAvisoLogin.ForeColor = System.Drawing.Color.Green;
                    lblAvisoLogin.Visible = true;

                    lblRecuEmail.Visible = false;
                    lblRecuDNI.Visible = false;
                    txtRecuEmail.Visible = false;
                    txtRecuDNI.Visible = false;
                    btnSiguiente.Visible = false;
                    lblNuevaContrasenia.Visible = false;
                    lblRepeNuevaContrasenia.Visible = false;
                    txtNuevaContrasenia.Visible = false;
                    txtRepeNuevaContrasenia.Visible = false;
                    btnRecuperar.Visible = false;
                }
                else { lblAvisoRecuperar.Text = "No se pudo actualizar la contraseña. Intente nuevamente"; }
            }
            else { lblAvisoRecuperar.Text = "Las contraseñas no coinciden. Intente nuevamente"; }

            

        }
    }
}