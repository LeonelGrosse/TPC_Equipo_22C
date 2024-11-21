using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
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
        public Evento EventoSeleccionado = new Evento();
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

        protected void btnParticipantes_Click(object sender, EventArgs e)
        {
            string idEvento = ((Button)sender).CommandArgument;
            Response.Redirect("Participantes.aspx?IdEvento=" + idEvento, false);
        }
        protected void btnCargarResultados_Click(object sender, EventArgs e)
        {
            OcultarCamposDisciplina();
            DropDownDNI.ClearSelection();
            DropDownDNI.Items.Clear();

            string argumment = ((Button)sender).CommandArgument;
            int idEvento = int.Parse(argumment);
            EventoSeleccionado = EventoNegocio.Listar(idEvento)[0];

            if (EventoNegocio.ObtenerUsuariosInscriptos(idEvento) != null || EventoNegocio.ObtenerUsuariosInscriptos(idEvento).Count() == 0)
            {
                DropDownDNI.DataSource = EventoNegocio.ObtenerUsuariosInscriptos(idEvento);
                DropDownDNI.DataBind();
            }

            MostrarCamposDisciplina();
            Div1.Visible = true;
        }
        protected void BtnCargar_Click(object sender, EventArgs e)
        {
            foreach (Disciplina disciplina in EventoSeleccionado.Disciplina)
            {
                TiempoPorDisciplina tiempo = new TiempoPorDisciplina();

                if (disciplina.Nombre == "Natación")
                {

                }

                if (disciplina.Nombre == "Ciclismo")
                {

                }

                if (disciplina.Nombre == "Atltetismo")
                {

                }

                //tiempo.IDDisciplina = ;
                //EventoSeleccionado.Resultado.Tiempo.Add();
            }
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Div1.Visible = false;
        }

        private void MostrarCamposDisciplina()
        {
            Evento evento = new Evento();
            foreach (Disciplina disciplina in EventoSeleccionado.Disciplina)
            {
                if (disciplina.ID == (int)Evento.DISCIPLINAS.Natacion)
                    ContainerNatacion.Visible = true;

                if (disciplina.ID == (int)Evento.DISCIPLINAS.Ciclismo)
                    ContainerCiclismo.Visible = true;

                if (disciplina.ID == (int)Evento.DISCIPLINAS.Running)
                    ContainerRunning.Visible = true;
            }
        }

        private void OcultarCamposDisciplina()
        {
            ContainerNatacion.Visible = false;
            ContainerCiclismo.Visible = false;
            ContainerRunning.Visible = false;
        }
    }
}