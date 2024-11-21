using accesorio;
using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class ModificarEvento : System.Web.UI.Page
    {
        EventoNegocio eventoNegocio = new EventoNegocio();
        Evento evento = new Evento();
        DisciplinaNegocio disciplinaNegocio = new DisciplinaNegocio();
        List<Disciplina> disciplinas = new List<Disciplina>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.RestringirAcceso(Session["UsuarioActivo"], Roles.Organizador))
                Response.Redirect("Eventos.aspx", false);

            int idEvento = int.Parse(Request.Params["IdEvento"].ToString());
            evento = eventoNegocio.Listar(idEvento)[0];
            disciplinas = disciplinaNegocio.ListarPorEvento(idEvento);
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
            txtFecha.Text = String.Format("{0:yyyy-MM-dd}", evento.FechaEvento);
            txtProvincia.Text = evento.Ubicacion.Ciudad.Provincia.Nombre;
            txtCiudad.Text = evento.Ubicacion.Ciudad.Nombre;
            txtCalle.Text = evento.Ubicacion.Direccion.Calle;
            txtAltura.Text = evento.Ubicacion.Direccion.Altura.ToString();
            txtCosto.Text = evento.CostoInscripcion.ToString();
            txtCupos.Text = evento.CuposDisponibles.ToString();
            txtEdadMinima.Text = evento.EdadMinima.ToString();
            txtEdadMaxima.Text = evento.EdadMaxima.ToString();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Evento aux = new Evento();
            aux.IdEvento = evento.IdEvento;
            aux.Nombre = txtNombre.Text;
            aux.FechaEvento = DateTime.Parse(txtFecha.Text);
            aux.Ubicacion.IDUbicacion = evento.Ubicacion.IDUbicacion;
            aux.Ubicacion.Direccion.Calle = txtCalle.Text;
            aux.Ubicacion.Direccion.Altura = txtAltura.Text;
            aux.CostoInscripcion = Decimal.Parse(txtCosto.Text);
            aux.CuposDisponibles = int.Parse(txtCupos.Text);
            aux.EdadMinima = int.Parse(txtEdadMinima.Text);
            aux.EdadMaxima = int.Parse(txtEdadMaxima.Text);
            aux.Estado = evento.Estado;
            eventoNegocio.modificar(aux);
            Response.Redirect("Eventos.aspx", false);
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Eventos.aspx", false);
        }

        protected void btnBorrarEvento_Click(object sender, EventArgs e)
        {
            int idEvento = int.Parse(Request.Params["IdEvento"].ToString());
            eventoNegocio.EliminarEvento(idEvento);
            Response.Redirect("Eventos.aspx", false);
        }
    }
}