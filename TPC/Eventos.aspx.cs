using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using accesorio;
using dominio;
using negocio;

namespace TPC
{
    public partial class Eventos : System.Web.UI.Page
    {
        public List<Evento> ListaEvento { get; set; }
        private EventoNegocio EventoNegocio = new EventoNegocio();
        private Filtro filtro = new Filtro();
        protected void Page_Load(object sender, EventArgs e)
        {
            EventoNegocio negocio = new EventoNegocio();
            ListaEvento = negocio.Listar();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaEvento;
                repRepetidor.DataBind();
                filtro.CargarDropDownOpciones(DropDownOpcionesFiltroEventos);
            }
        }

        public string ObtenerDescripciones(List<Disciplina> disciplinas)
        {
            return string.Join(", ", disciplinas.Select(d => d.Nombre));
        }
        private void CargarRepeater(List<Evento> eventos)
        {
            repRepetidor.DataSource = eventos;
            repRepetidor.DataBind();
        }

        protected void btnInscribirse_Click(object sender, EventArgs e)
        {
            if (Session["UsuarioActivo"] != null)
            {
                string idEvento = ((Button)sender).CommandArgument;
                Response.Redirect("DetallesEvento.aspx?IdEvento=" + idEvento, false);
            }
            else Response.Redirect("Login.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string idEvento = ((Button)sender).CommandArgument;
            Response.Redirect("ModificarEvento.aspx?IdEvento=" + idEvento, false);
        }

        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Evento evento = (Evento)e.Item.DataItem;
                Repeater repeaterDisciplinas = (Repeater)e.Item.FindControl("RepeaterDisciplinas");
                repeaterDisciplinas.DataSource = evento.Disciplina;
                repeaterDisciplinas.DataBind();
            }
        }

        protected void DropDownOpcionesFiltroEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Provincia> Provincias = new ProvinciaNegocio().ObtenerProvincias();
            List<Disciplina> Disciplinas = new DisciplinaNegocio().Listar();

            string campo = DropDownOpcionesFiltroEventos.SelectedItem.Value.ToString();

            filtro.SetearDropDownPorCampo(campo, DropDownListCriterioEventos, Disciplinas, Provincias);

            Session.Add("ValorFiltroCampo", campo);
        }

        protected void DropDownListCriterioEventos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int criterio = int.Parse(DropDownListCriterioEventos.SelectedItem.Value);
            Session.Add("ValorFiltroCriterio", criterio);
        }
        protected void BtnFiltrarEvento_Click(object sender, EventArgs e)
        {
            List<Evento> eventoFiltrado = new List<Evento>();

            try
            {
                if (DropDownListCriterioEventos.SelectedItem == null)
                {
                    MostrarMensajeError("Seleccione un campo de busqueda antes de filtrar.");
                    return;
                }

                int valorCriterioDefault = int.Parse(DropDownListCriterioEventos.SelectedItem.Value); // Si no hay nada seleccionado se rompe.

                if (Session["ValorFiltroCriterio"] == null)
                {
                    Session["ValorFiltroCriterio"] = valorCriterioDefault;
                }

                if (!(Session["ValorFiltroCampo"].ToString() == "Disciplina"))
                    eventoFiltrado = EventoNegocio.Filtrar(Session["ValorFiltroCampo"].ToString(), int.Parse(Session["ValorFiltroCriterio"].ToString()));
                else
                    eventoFiltrado = filtro.FiltrarPorDisciplina(RetornarListaOriginal(), int.Parse(DropDownListCriterioEventos.SelectedItem.Value));

                CargarRepeater(eventoFiltrado);

                if (eventoFiltrado.Count == 0)
                {
                    string mensaje = "Aun no se existe un evento con estas características.";
                    MostrarMsjEventosObtenidos(mensaje);
                }
                else
                {
                    MostrarMsjEventosObtenidos("", false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        protected void BtnLimpiarFiltroEvento_Click(object sender, EventArgs e)
        {
            if (ListaEvento.Count() == 0 || ListaEvento == null)
            {
                string mensaje = "No hay eventos cargados.";
                MostrarMsjEventosObtenidos(mensaje);
            }
            else
            {
                MostrarMsjEventosObtenidos("", false);
            }

            DropDownOpcionesFiltroEventos.ClearSelection();
            DropDownListCriterioEventos.Items.Clear();
            CargarRepeater(RetornarListaOriginal());
        }

        private void MostrarMsjEventosObtenidos(string mensaje, bool ocultarCampos = true)
        {
            MsjReporteBusquedaEventos.InnerText = mensaje;
            MsjReporteBusquedaEventos.Visible = ocultarCampos;
        }

        private List<Evento> RetornarListaOriginal()
        {
            return EventoNegocio.Listar();
        }

        protected void BtnVolverInicio_Click(object sender, EventArgs e)
        {
            MostrarMensajeError("", false);
        }

        private void MostrarMensajeError(string mensaje, bool visible = true)
        {
            ContainerCard.Visible = visible;
            CardMsj.Text = mensaje;
        }
    }
}