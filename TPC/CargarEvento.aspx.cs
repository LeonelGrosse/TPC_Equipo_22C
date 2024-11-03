﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            }
        }

        protected void BtnCargarEvento_Click(object sender, EventArgs e)
        {
            CapturarValores();
            EventoNegocio.RegistrarEvento(NuevoEvento);
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

                NuevoEvento.CostoInscripcion = decimal.Parse(CostoEvento.Text);
                NuevoEvento.CuposDisponibles = int.Parse(CuposDisponibles.Text);

                NuevoEvento.EdadMinima = int.Parse(EdadMinEvento.Text);
                NuevoEvento.EdadMaxima = int.Parse(EdadMaxEvento.Text);

                NuevoEvento.Disciplina.Descripcion = Disciplina1.Text;
                NuevoEvento.Estado = 'D';
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
    }
}