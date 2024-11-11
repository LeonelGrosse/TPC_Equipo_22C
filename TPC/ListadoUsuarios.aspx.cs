using accesorio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class ListadoUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.RestringirAcceso(Session["UsuarioActivo"], Roles.Administrador))
                Response.Redirect("Default.aspx", false);
        }
    }
}