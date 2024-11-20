﻿using accesorio;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Discovery;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class DetallesEvento : System.Web.UI.Page
    {
        EventoNegocio eventoNegocio = new EventoNegocio();
        Evento evento = new Evento();
        DisciplinaNegocio disciplinaNegocio = new DisciplinaNegocio();
        List<Disciplina> disciplinas = new List<Disciplina>();
        Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.RestringirAcceso(Session["UsuarioActivo"], Roles.Participante))
                Response.Redirect("Default.aspx", false);

            int idEvento = int.Parse(Request.Params["IdEvento"].ToString());
            evento=eventoNegocio.BuscarPorID(idEvento);
            disciplinas=disciplinaNegocio.ListarPorEvento(idEvento);
            if (!IsPostBack)
            {
                repRepetidor.DataSource = disciplinas;
                repRepetidor.DataBind();
                CargarDatosEvento();
            }
        }

        public void CargarDatosEvento()
        {
            txtNombre.Text = evento.Nombre;
            txtFecha.Text = evento.FechaEvento.ToString("dd-MM-yyyy");
            txtProvincia.Text = evento.Ubicacion.Ciudad.Provincia.Nombre;
            txtCiudad.Text = evento.Ubicacion.Ciudad.Nombre;
            txtCalle.Text = evento.Ubicacion.Direccion.Calle;
            txtAltura.Text = evento.Ubicacion.Direccion.Altura.ToString();
            txtCosto.Text = ((int)evento.CostoInscripcion).ToString();
            txtCupos.Text = evento.CuposDisponibles.ToString();
            txtEdadMinima.Text = evento.EdadMinima.ToString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int idEvento = int.Parse(Request.Params["IdEvento"].ToString());
            usuario = (Usuario)Session["UsuarioActivo"];
            int idUsuario = usuario.IdUsuario;
            eventoNegocio.InscribirseEvento(idEvento, idUsuario);
            Response.Redirect("InscripcionExitosa.aspx", false);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Eventos.aspx", false);
        }
    }
}