using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    }
}