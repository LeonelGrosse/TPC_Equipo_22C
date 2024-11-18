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
        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private List<Evento> eventosInscripto = new List<Evento>();
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
                ColorEstado();
            }

        }

        protected void btnVerEvento_Click(object sender, EventArgs e)
        {
            Response.Redirect("Eventos.aspx", false);
        }

        public bool ExistenInscripciones()
        {
            return eventosInscripto.Count > 0 && eventosInscripto != null;
        }

        private void ColorEstado()
        {
            foreach (RepeaterItem repeater in RepeaterEventosUsuario.Items)
            {
                Label labelEstado = repeater.FindControl("estadoEvento") as Label;

                if (labelEstado != null)
                {
                    foreach (Evento evento in eventosInscripto)
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

            if (!usuarioNegocio.CancelarInscripcion(btnCommandArgument, Seguridad.UsuarioLogueado.IdUsuario))
            {
                Console.WriteLine("No es posible cancelar la inscripción.");
                return;
            }
            
            Console.WriteLine("Se ha dado de baja correctamente");
            CargarRepeater();
            ColorEstado();
        }

        private void CargarRepeater()
        {
            eventosInscripto = usuarioNegocio.ListarEventos(Seguridad.UsuarioLogueado.IdUsuario);
            RepeaterEventosUsuario.DataSource = eventosInscripto;
            RepeaterEventosUsuario.DataBind();
        }
    }
}