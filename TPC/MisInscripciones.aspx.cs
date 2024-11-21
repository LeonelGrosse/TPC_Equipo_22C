using accesorio;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class MisInscripciones : System.Web.UI.Page
    {
        private UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();
        private List<Evento> EventosInscripto = new List<Evento>();
        private Filtro filtro = new Filtro();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.RestringirAcceso(Session["UsuarioActivo"], Roles.Participante))
            {
                Response.Redirect("Default.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                EventosInscripto = RetornarListaOriginal();
                CargarRepeater(EventosInscripto);

                if (EventosInscripto.Count() == 0 || EventosInscripto == null)
                {
                    string mensaje = "Aun no se ha inscrito a ningun evento";
                    MostrarMsjEventosObtenidos(mensaje);
                }

                SetearColorSegunEstado();
                filtro.CargarDropDownOpciones(DropDownOpcionesFiltro);
            }
        }

        protected void btnVerEvento_Click(object sender, EventArgs e)
        {
            Response.Redirect("Eventos.aspx", false);
        }

        public bool ExistenInscripciones()
        {
            return EventosInscripto.Count > 0 && EventosInscripto != null;
        }

        private void SetearColorSegunEstado()
        {
            foreach (RepeaterItem repeater in RepeaterEventosUsuario.Items)
            {
                Label labelEstado = repeater.FindControl("estadoEvento") as Label;

                if (labelEstado != null)
                {
                    foreach (Evento evento in EventosInscripto)
                    {
                        switch (evento.Estado)
                        {
                            case 'D':
                                labelEstado.Text = "Disponible";
                                labelEstado.CssClass = "evento-disponible card-text";
                                break;
                            case 'C':
                                labelEstado.Text = "Cancelado";
                                labelEstado.CssClass = "evento-candelado card-text";
                                break;
                            case 'F':
                                labelEstado.Text = "Finalizado";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        protected void btnCancelarInscripcion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int btnCommandArgument = int.Parse(btn.CommandArgument);

            if (!UsuarioNegocio.CancelarInscripcion(btnCommandArgument, Seguridad.UsuarioLogueado.IdUsuario))
            {
                Console.WriteLine("No es posible cancelar la inscripción.");
                return;
            }

            Console.WriteLine("Se ha dado de baja correctamente");

            EventosInscripto = RetornarListaOriginal();
            CargarRepeater(EventosInscripto);

            if (EventosInscripto.Count() == 0 || EventosInscripto == null)
            {
                string mensaje = "Aun no se ha inscrito a ningun evento";
                MostrarMsjEventosObtenidos(mensaje);
            }
            else
            {
                MostrarMsjEventosObtenidos("", false);
            }
            SetearColorSegunEstado();
        }

        private void CargarRepeater(List<Evento> eventos)
        {
            RepeaterEventosUsuario.DataSource = eventos;
            RepeaterEventosUsuario.DataBind();
        }

        protected void DropDownOpcionesFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Provincia> Provincias = new ProvinciaNegocio().ObtenerProvincias();
            List<Disciplina> Disciplinas = new DisciplinaNegocio().Listar();

            string campo = DropDownOpcionesFiltro.SelectedItem.Value.ToString();

            filtro.SetearDropDownPorCampo(campo, DropDownListCriterio, Disciplinas, Provincias);
           
            Session.Add("ValorFiltroCampo", campo);
        }

        protected void DropDownListCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int criterio = int.Parse(DropDownListCriterio.SelectedItem.Value);
            Session.Add("ValorFiltroCriterio", criterio);
        }

        protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
            List<Evento> eventoFiltrado = new List<Evento>();

           if(DropDownListCriterio.SelectedItem == null)
            {
                MostrarMensajeError("Seleccione un campo de busqueda antes de filtrar.");
                return;
            }

            int valorCriterioDefault = int.Parse(DropDownListCriterio.SelectedItem.Value); // Si no hay nada seleccionado se rompe.

            try
            {
                if (Session["ValorFiltroCriterio"] == null)
                {
                    Session["ValorFiltroCriterio"] = valorCriterioDefault;
                }

                if (!(Session["ValorFiltroCampo"].ToString() == "Disciplina"))
                    eventoFiltrado = UsuarioNegocio.Filtrar(Session["ValorFiltroCampo"].ToString(), int.Parse(Session["ValorFiltroCriterio"].ToString()), Seguridad.UsuarioLogueado.IdUsuario);
                else
                    eventoFiltrado = filtro.FiltrarPorDisciplina(RetornarListaOriginal(), int.Parse(DropDownListCriterio.SelectedItem.Value));

                CargarRepeater(eventoFiltrado);

                if (eventoFiltrado.Count == 0)
                {
                    string mensaje = "Aun no se ha inscrito a ningun evento con estas características.";
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

        protected void BtnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            EventosInscripto = RetornarListaOriginal();
            CargarRepeater(EventosInscripto);

            if (EventosInscripto.Count() == 0 || EventosInscripto == null)
            {
                string mensaje = "Aun no se ha inscrito a ningun evento";
                MostrarMsjEventosObtenidos(mensaje);
            }
            else
            {
                MostrarMsjEventosObtenidos("", false);
            }

            DropDownOpcionesFiltro.ClearSelection();
            DropDownListCriterio.Items.Clear();
        }

        private List<Evento> RetornarListaOriginal()
        {
            return UsuarioNegocio.ListarEventos(Seguridad.UsuarioLogueado.IdUsuario);
        }

        private void MostrarMsjEventosObtenidos(string mensaje, bool ocultarCampos = true)
        {
            MsjInscripciones.InnerText = mensaje;
            MsjInscripciones.Visible = ocultarCampos;
            btnVerEvento.Visible = ocultarCampos;
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