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
            if ((Page is Default))
            {
                nav_ul_admin.Visible = false;
                nav_ul_organizador.Visible = false;
                nav_ul_participante.Visible = false;
            }
            else
            {
                navbar_ul_default.Visible = false;
            }

            /*if (UserControl == admin) oculto las pages que no necesite el admin
            { 
            }*
            
            //*if (UserControl == participante) oculto las pages que no necesite el participante
            { 
            }*
            
            //*if (UserControl == organizador) oculto las pages que no necesite el organizador
            { 
            }*/


        }
    }
}