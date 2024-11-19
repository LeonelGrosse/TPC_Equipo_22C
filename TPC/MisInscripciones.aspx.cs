using accesorio;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class MisInscripciones : System.Web.UI.Page
    {
        private UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();
        private List<Evento> EventosInscripto = new List<Evento>();
        private List<Provincia> Provincias = new List<Provincia>();
        private List<Disciplina> Disciplinas = new List<Disciplina>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.RestringirAcceso(Session["UsuarioActivo"], Roles.Participante))
            {
                Response.Redirect("Default.aspx", false);
                return;
            }

            if (!IsPostBack)
            {
                CargarRepeater();
                SetearColorSegunEstado();
                CargarDesplegables();
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
            CargarRepeater();
            SetearColorSegunEstado();
        }

        private void CargarRepeater()
        {
            EventosInscripto = UsuarioNegocio.ListarEventos(Seguridad.UsuarioLogueado.IdUsuario);
            RepeaterEventosUsuario.DataSource = EventosInscripto;
            RepeaterEventosUsuario.DataBind();
        }

        private void CargarDesplegables()
        {
            Provincias = new ProvinciaNegocio().ObtenerProvincias();
            Disciplinas = new DisciplinaNegocio().Listar();

            Helper.CargarDropDown(DropDownFiltroProvincias, "ID", "Nombre", Provincias);
            Helper.CargarDropDown(DropDownFiltroDisciplina, "IdDisciplina", "Descripcion", Disciplinas);

            DropDownFiltroCosto.Items.Add("Mayor precio");
            DropDownFiltroCosto.Items.Add("Menor precio");
            DropDownFiltroFecha.Items.Add("Más recientes");
            DropDownFiltroFecha.Items.Add("Más antiguos");
        }
    }
}