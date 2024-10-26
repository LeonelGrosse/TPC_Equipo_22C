using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class EventoNegocio
    {
        List<Evento> lista = new List<Evento>();
        AccesoDatos datos = new AccesoDatos();

        public List<Evento> listar()
        {
            string select = "SELECT e.IDEvento, e.Nombre, e.FechaEvento, c.Nombre as Ciudad, e.CostoInscripcion, e.Estado, e.EdadMinima, e.CuposDisponibles, i.ImgURL, d.Disciplina ";
            string from = "FROM Evento e INNER JOIN Imagen_x_Evento ie On ie.IDEvento = e.IDEvento INNER JOIN Imagen i On i.ID = ie.IDImagen INNER JOIN Disciplina_x_Evento de On de.IDEvento =e.IDEvento INNER JOIN Disciplina d On d.IDDisciplina = de.IDDisciplina INNER JOIN Ciudad c On c.IDCiudad = e.Ubicacion";

            try
            {
                datos.setConsulta(select + from);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Evento aux = new Evento();
                    aux.IdEvento = (int)(Int64)datos.Lector["IDEvento"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.FechaEvento = (DateTime)datos.Lector["FechaEvento"];

                    aux.Ubicacion = new Ubicacion();
                    aux.Ubicacion.Ciudad.Nombre = (string)datos.Lector["Ciudad"];

                    aux.CostoInscripcion = (decimal)datos.Lector["CostoInscripcion"];

                    aux.Estado = (char)datos.Lector["Estado"];
                    aux.RangoEdad = (int)datos.Lector["EdadMinima"];
                    aux.CuposDisponibles = (int)datos.Lector["CuposDisponibles"];

                    aux.Disciplina = new Disciplina();
                    aux.Disciplina.Descripcion = (string)datos.Lector["Disciplina"];

                    aux.Imagen = new Imagen();
                    if (!(datos.Lector["ImgURL"] is DBNull))
                    {
                        aux.Imagen.URL = (string)datos.Lector["ImgURL"];
                    }

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
