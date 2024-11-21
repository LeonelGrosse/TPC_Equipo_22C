using dominio;
using accesorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.SesionActiva(Session["UsuarioActivo"]))
            {
                if (Seguridad.UsuarioLogueado.EsAdministrador())
                    CargarVistaAministrador();

                if (Seguridad.UsuarioLogueado.EsOrganizador())
                    CargarVistaOrganizador();

                if (Seguridad.UsuarioLogueado.EsParticipante())
                    CargarVistaParticipante();

                navbar_ul_accesos.Visible = false;
            }
            else
            {
                CargarVistaDefault();
            }
        }

        private void CargarVistaDefault()
        {
            nav_ul_admin.Visible = false;
            nav_ul_participante.Visible = false;
            nav_ul_organizador.Visible = false;
        }
        private void CargarVistaOrganizador()
        {
            nav_ul_admin.Visible = false;
            nav_ul_participante.Visible = false;
        }
        private void CargarVistaAministrador()
        {
            nav_ul_organizador.Visible = false;
            nav_ul_participante.Visible = false;
        }
        private void CargarVistaParticipante()
        {
            nav_ul_admin.Visible = false;
            nav_ul_organizador.Visible = false;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("UsuarioActivo");
            Response.Redirect("Default.aspx", false);
        }

        protected void btnLogout2_Click(object sender, EventArgs e)
        {
            Session.Remove("UsuarioActivo");
            Response.Redirect("Default.aspx", false);
        }

        protected void btnLogout3_Click(object sender, EventArgs e)
        {
            Session.Remove("UsuarioActivo");
            Response.Redirect("Default.aspx", false);
        }
    }
}