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
        List<Evento> Lista = new List<Evento>();
        AccesoDatos Datos = new AccesoDatos();

        public List<Evento> Listar()
        {
            string select = "SELECT e.IDEvento, e.Nombre, e.FechaEvento, c.Nombre as Ciudad, e.CostoInscripcion, e.Estado, e.EdadMinima, e.CuposDisponibles, i.ImgURL, d.Disciplina ";
            string from = "FROM Evento e INNER JOIN Imagen_x_Evento ie On ie.IDEvento = e.IDEvento INNER JOIN Imagen i On i.ID = ie.IDImagen INNER JOIN Disciplina_x_Evento de On de.IDEvento =e.IDEvento INNER JOIN Disciplina d On d.IDDisciplina = de.IDDisciplina INNER JOIN Ciudad c On c.IDCiudad = e.Ubicacion";

            try
            {
                Datos.setConsulta(select + from);
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Evento aux = new Evento();
                    aux.IdEvento = (int)(Int64)Datos.Lector["IDEvento"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.FechaEvento = (DateTime)Datos.Lector["FechaEvento"];

                    aux.Ubicacion = new Ubicacion();
                    aux.Ubicacion.Ciudad.Nombre = (string)Datos.Lector["Ciudad"];

                    aux.CostoInscripcion = (decimal)Datos.Lector["CostoInscripcion"];

                    //aux.Estado = (char)Datos.Lector["Estado"];
                    aux.EdadMinima = (int)Datos.Lector["EdadMinima"];
                    aux.CuposDisponibles = (int)Datos.Lector["CuposDisponibles"];

                    aux.Disciplina = new Disciplina();
                    aux.Disciplina.Descripcion = (string)Datos.Lector["Disciplina"];

                    aux.Imagen = new Imagen();
                    if (!(Datos.Lector["ImgURL"] is DBNull))
                    {
                        aux.Imagen.URL = (string)Datos.Lector["ImgURL"];
                    }

                    Lista.Add(aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }

        public void RegistrarEvento(Evento evento)
        {
            try
            {
                Datos.SetStoredProcedure("SP_INSERTAR_EVENTO");
                Datos.setParametro("@CALLE", evento.Ubicacion.Direccion.Calle);
                Datos.setParametro("@ALTURA", evento.Ubicacion.Direccion.Altura);
                Datos.setParametro("@ID_CIUDAD", evento.Ubicacion.Ciudad.IdCiudad);
                Datos.setParametro("@NOMBRE", evento.Nombre);
                Datos.setParametro("@FECHA", evento.FechaEvento);
                Datos.setParametro("@COSTO_INSCRIPCION", evento.CostoInscripcion);
                Datos.setParametro("@ESTADO", evento.Estado);
                Datos.setParametro("@EDAD_MINIMA", evento.EdadMinima);
                Datos.setParametro("@EDAD_MAXIMA", evento.EdadMaxima);
                Datos.setParametro("@CUPOS_DISPONIBLES", evento.CuposDisponibles);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
