﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSerOrganizador_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrganizadorFormulario.aspx", false);
        }

        protected void BtnSerParticipante_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioRegistro.aspx", false);
        }
    }
}