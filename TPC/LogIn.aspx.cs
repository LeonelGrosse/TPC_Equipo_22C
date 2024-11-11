using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using accesorio;

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

            if (!(LoginOK == true))
            {
                lblAvisoLogin.Text = "El usuario o la contraseña no es válido";
                lblAvisoLogin.ForeColor = System.Drawing.Color.Red;
                lblAvisoLogin.Visible = true;
                return;
            }

            Usuario usuarioActivo = new Usuario();
            negocio.Login(usuarioActivo, txtUsuario.Text, txtContrasenia.Text);
            Session.Add("UsuarioActivo", usuarioActivo);

            if (usuarioActivo.EsAdministrador())
            {
                Response.Redirect("ListadoEventos.aspx", false);
            }
            if (usuarioActivo.EsParticipante())
            {
                Response.Redirect("Eventos.aspx", false);
            }
            if (usuarioActivo.EsOrganizador())
            {
                Response.Redirect("CargarEvento.aspx", false);
            }
        }
    }
}