using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace accesorio
{
    public class Filtro
    {
        public string query { get; set; }

        public enum DISCIPLINAS
        {
            Natacion = 1,
            Ciclismo = 2,
            Running = 3
        }

        public enum PRECIO
        {
            Mayor_Precio = 1,
            Menor_Precio = 2
        }

        public enum FECHA
        {
            Mas_Antiguos = 1,
            Mas_Recientes = 2
        }

        public void SetearQueryBase(string query)
        {
            this.query = query;
        }
        public string AplicarCriterioAQuery(string campo, int criterio)
        {
            if (campo == "Provincia")
            {
                this.query += $" AND IDProvincia = {criterio}";
            }

            if (campo == "Precio")
            {
                switch (criterio)
                {
                    case (int)Filtro.PRECIO.Mayor_Precio:
                        this.query += " ORDER BY E.CostoInscripcion DESC";
                        break;
                    case (int)Filtro.PRECIO.Menor_Precio:
                        this.query += " ORDER BY E.CostoInscripcion ASC";
                        break;
                    default:
                        break;
                }
            }

            if (campo == "Fecha")
            {
                switch (criterio)
                {
                    case (int)Filtro.FECHA.Mas_Antiguos:
                        this.query += " ORDER BY E.FechaEvento DESC";
                        break;
                    case (int)Filtro.FECHA.Mas_Recientes:
                        break;
                        this.query += " ORDER BY E.FechaEvento ASC";
                    default:
                        break; 
                }
            }
            return query;
        }
        public void SetearDropDownPorCampo(string campo, DropDownList DropDownListCriterio, List<Disciplina> disciplinas, List<Provincia> provincias)
        {
            List<Provincia> Provincias = new List<Provincia>();
            List<Disciplina> Disciplinas = new List<Disciplina>();

            DropDownListCriterio.Items.Clear();
            switch (campo)
            {
                case "Fecha":
                    CargarDropDownGenerico(DropDownListCriterio, new Dictionary<string, string>
                    {
                        { "1", "Más recientes" },
                        { "2", "Más antiguos" }
                    });
                    break;
                case "Disciplina":
                    CargarDropDownSegunLista(disciplinas, DropDownListCriterio);
                    break;
                case "Provincia":
                    CargarDropDownSegunLista(provincias, DropDownListCriterio);
                    break;
                case "Precio":
                    Dictionary<string, string> OpcionesDropDownPrecio = new Dictionary<string, string>
                    {
                        { "1", "Mayor precio" },
                        { "2", "Menor precio" }
                    };
                    CargarDropDownGenerico(DropDownListCriterio, new Dictionary<string, string>
                    {
                        { "1", "Mayor precio" },
                        { "2", "Menor precio" }
                    });
                    break;
                default:
                    DropDownListCriterio.Items.Clear();
                    break;
            }
        }

        public void CargarDropDownSegunLista<T>(IEnumerable<T> lista, DropDownList DropDownListCriterio)
        {
            Helper.CargarDropDown(DropDownListCriterio, "ID", "Nombre", lista);
        }

        public void CargarDropDownOpciones(DropDownList DropDownOpcionesFiltro)
        {
            DropDownOpcionesFiltro.Items.Clear();
            DropDownOpcionesFiltro.Items.Add("Seleccionar campo");
            DropDownOpcionesFiltro.Items.Add("Fecha");
            DropDownOpcionesFiltro.Items.Add("Disciplina");
            DropDownOpcionesFiltro.Items.Add("Provincia");
            DropDownOpcionesFiltro.Items.Add("Precio");
        }

        public void CargarDropDownGenerico(DropDownList DropDownListCriterio, Dictionary<string, string> opciones)
        {
            foreach (var opcion in opciones)
            {
                DropDownListCriterio.Items.Add(new ListItem(opcion.Value, opcion.Key));
            }
        }

        public List<Evento> FiltrarPorDisciplina(List<Evento> eventos, int idDisciplina)
        {
            try
            {
                switch (idDisciplina)
                {
                    case 1:
                        eventos = eventos.FindAll(evento => evento.Disciplina.Any(disciplina => disciplina.ID == idDisciplina));
                        break;
                    case 2:
                        eventos = eventos.FindAll(evento => evento.Disciplina.Any(disciplina => disciplina.ID == idDisciplina));
                        break;
                    case 3:
                        eventos = eventos.FindAll(evento => evento.Disciplina.Any(disciplina => disciplina.ID == idDisciplina));
                        break;
                    default:
                        break;
                }

                return eventos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
