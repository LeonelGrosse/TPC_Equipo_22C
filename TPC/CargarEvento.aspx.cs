using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TPC
{
    public partial class CargarEvento : System.Web.UI.Page
    {
        private Evento NuevoEvento;
        private EventoNegocio EventoNegocio;
        private ProvinciaNegocio provinciaNegocio;
        private CiudadNegocio ciudadNegocio;
        List<Provincia> provincias;
        List<Ciudad> ciudades;
        static int contadorDisciplina = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
                NuevoEvento = new Evento();
                EventoNegocio = new EventoNegocio();
                provinciaNegocio = new ProvinciaNegocio();
                ciudadNegocio = new CiudadNegocio();
                provincias = new List<Provincia>();
                ciudades = new List<Ciudad>();

            if (!IsPostBack)
            {
                CargarDesplegables();
                contadorDisciplina = 0;
            }
        }

        protected void BtnCargarEvento_Click(object sender, EventArgs e)
        {
            CapturarValores();
            EventoNegocio.RegistrarEvento(NuevoEvento);
                if (NuevoEvento.IdEvento != 0)
                {
                    foreach (Disciplina disciplina in NuevoEvento.Disciplina)
                    {
                        EventoNegocio.RegistrarDisciplina(NuevoEvento.IdEvento, disciplina);
                    }

                    if(NuevoEvento.Imagen.URL != null)
                    {
                        ImagenNegocio imagenNegocio = new ImagenNegocio();
                        NuevoEvento.Imagen.ID = imagenNegocio.Insertar(NuevoEvento.Imagen.URL);

                        imagenNegocio.AsociarEvento(NuevoEvento.Imagen.ID, NuevoEvento.IdEvento);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BtnAgregarDisciplina_Click(object sender, EventArgs e)
        {
            List<Disciplina> discplina = new DisciplinaNegocio().Listar();

            if (contadorDisciplina <= 1)
            {
                CargarDropDown(DropDownDisciplina2, "IdDisciplina", "Descripcion", discplina);
                containerDisciplina2.Visible = true;
            }

            if (contadorDisciplina >= 1)
            {
                CargarDropDown(DropDownDisciplina3, "IdDisciplina", "Descripcion", discplina);
                containerDisciplina3.Visible = true;
            }
            contadorDisciplina++;
        }

        protected void btnQuitarDisciplina2_Click(object sender, EventArgs e)
        {
            containerDisciplina2.Visible = false;
            contadorDisciplina--;
        }

        protected void btnQuitarDisciplina3_Click(object sender, EventArgs e)
        {
            containerDisciplina3.Visible = false;
            contadorDisciplina--;
        }

        protected void TxtImgUrl_TextChanged(object sender, EventArgs e)
        {
            ImgEvento.ImageUrl = TxtImgUrl.Text;
        }

        protected void BtnCancelarCarga_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void CapturarValores()
        {
            try
            {
                NuevoEvento.Nombre = NombreEvento.Text;
                NuevoEvento.FechaEvento = DateTime.Parse(FechaEvento.Text);

                NuevoEvento.Ubicacion.Ciudad.IdCiudad = int.Parse(DropDownCiudades.SelectedItem.Value);
                NuevoEvento.Ubicacion.Ciudad.Nombre = DropDownCiudades.SelectedItem.ToString();

                NuevoEvento.Ubicacion.Direccion.Calle = CalleEvento.Text;
                NuevoEvento.Ubicacion.Direccion.Altura = AlturaEvento.Text;

                NuevoEvento.CostoInscripcion = CostoEvento.Text == "" ? 0 : decimal.Parse(CostoEvento.Text);
                NuevoEvento.CuposDisponibles = int.Parse(CuposDisponibles.Text);

                NuevoEvento.EdadMinima = EdadMinEvento.Text == "" ? 0 : int.Parse(EdadMinEvento.Text);
                NuevoEvento.EdadMaxima = EdadMaxEvento.Text  == "" ? 0 : int.Parse(EdadMaxEvento.Text);

                AgregarDisciplina(NuevoEvento, containerDisciplina, DistanciaDisciplina1, DropDownDisciplina);
                AgregarDisciplina(NuevoEvento, containerDisciplina2, DistanciaDisciplina2, DropDownDisciplina2);
                AgregarDisciplina(NuevoEvento, containerDisciplina3, DistanciaDisciplina3, DropDownDisciplina3);

                NuevoEvento.Imagen.URL = TxtImgUrl.Text;

                NuevoEvento.Estado = 'D';
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarDisciplina(Evento NuevoEvento, HtmlGenericControl container, TextBox txtDistancia, DropDownList dpdDisciplina)
        {
            try
            {
                if (container.Visible == true)
                {
                    Disciplina disciplina = new Disciplina();
                    disciplina.IdDisciplina = int.Parse(dpdDisciplina.SelectedItem.Value);
                    disciplina.Descripcion = dpdDisciplina.SelectedItem.Value.ToString();
                    disciplina.Distancia = decimal.Parse(txtDistancia.Text);
                    NuevoEvento.Disciplina.Add(disciplina);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargarDesplegables()
        {
            List<Provincia> provincias = provinciaNegocio.ObtenerProvincias();
            List<Ciudad> ciudades = ciudadNegocio.ObtenerConStoredProcedure();
            List<Disciplina> discplina = new DisciplinaNegocio().Listar();

            CargarDropDown(DropDownDisciplina, "IdDisciplina", "Descripcion", discplina);
            CargarDropDown(DropDownProvincias, "ID", "Nombre", provincias);

            int IDProvincia = int.Parse(DropDownProvincias.SelectedItem.Value);
            List<Ciudad> CiudadesFiltradas = ciudades.FindAll(Ciudad => Ciudad.Provincia.ID == IDProvincia);
            CargarDropDown(DropDownCiudades, "IdCiudad", "Nombre", CiudadesFiltradas);

            Session["Ciudades"] = ciudades;
        }

        protected void DropDownProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDProvincia = int.Parse(DropDownProvincias.SelectedItem.Value);
            List<Ciudad> CiudadesFiltradas = ((List<Ciudad>)Session["Ciudades"]).FindAll(Ciudad => Ciudad.Provincia.ID == IDProvincia);
            CargarDropDown(DropDownCiudades, "IdCiudad", "Nombre", CiudadesFiltradas);
        }

        private void CargarDropDown<T>(DropDownList dropDown, string dataValueField, string dataTextField, IEnumerable<T> lista)
        {
            dropDown.DataSource = lista;
            dropDown.DataValueField = dataValueField;
            dropDown.DataTextField = dataTextField;
            dropDown.DataBind();
        }

        private void LimpiarCampos()
        {
            NombreEvento.Text = "";
            CalleEvento.Text = "";
            AlturaEvento.Text = "";
            CostoEvento.Text = "";
            CuposDisponibles.Text = "";
            EdadMinEvento.Text = "";
            EdadMaxEvento.Text = "";
        }
    }
}