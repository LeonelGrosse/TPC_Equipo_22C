﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPC
{
    public partial class Eventos : System.Web.UI.Page
    {
        public List<Evento> ListaEvento { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            EventoNegocio negocio = new EventoNegocio();
            ListaEvento = negocio.Listar();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaEvento;
                repRepetidor.DataBind();
            }
        }

        public string ObtenerDescripciones(List<Disciplina> disciplinas)
        {
            return string.Join(", ", disciplinas.Select(d => d.Descripcion));
        }

        protected void btnInscribirse_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetallesEvento.aspx", false);
        }
    }
}