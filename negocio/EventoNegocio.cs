using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
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
            string select = "Select e.IDEvento, e.Nombre, e.FechaEvento, e.CostoInscripcion, e.EdadMinima, e.CuposDisponibles, e.Estado, p.IDPais, p.Nombre as Pais, c.IDCiudad, c.Nombre as Ciudad, dire.ID, dire.Calle, dire.Altura, dire.CodigoPostal, d.IDDisciplina, d.Disciplina, i.ID, i.ImgURL ";
            string from = "from Evento e Inner join Disciplina_x_Evento de On de.IDEvento = e.IDEvento Inner join Disciplina d On d.IDDisciplina = de.IDDisciplina Inner join Imagen_x_Evento ie On ie.IDEvento = e.IDEvento Inner join Imagen i On i.ID = ie.IDImagen Inner join Ubicacion u On u.IDUbicacion = e.Ubicacion Inner join Ciudad c On c.IDCiudad = u.IDCiudad Inner join Pais p On p.IDPais = c.IDPais Inner join Direccion dire On dire.ID = u.IDDireccion Where e.Estado = 'D'";
            
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
                    aux.Ubicacion.Ciudad.Nombre = (string)datos.Lector["Ciudad"];
                    aux.Ubicacion.Ciudad.Pais.IdPais = (int)(Int64)datos.Lector["IDPais"];
                    aux.Ubicacion.Ciudad.Pais.Nombre = (string)datos.Lector["Pais"];
                    aux.Ubicacion.Direccion.ID = (short)datos.Lector["ID"];
                    aux.Ubicacion.Direccion.Calle = (string)datos.Lector["Calle"];
                    aux.Ubicacion.Direccion.Altura = (string)datos.Lector["Altura"];
                    aux.Ubicacion.Direccion.CodigoPostal = (string)datos.Lector["CodigoPostal"];

                    aux.CostoInscripcion = (decimal)Datos.Lector["CostoInscripcion"];

                    aux.Estado = (char)datos.Lector["Estado"];
                    aux.RangoEdad = (int)datos.Lector["EdadMinima"];
                    aux.CuposDisponibles = (int)datos.Lector["CuposDisponibles"];

                    aux.Disciplina = new Disciplina();
                    aux.Disciplina.Descripcion = (string)datos.Lector["Disciplina"];

                    aux.Imagen = new Imagen();
                    if (!(Datos.Lector["ImgURL"] is DBNull))
                    {
                        aux.Imagen.URL = (string)datos.Lector["ImgURL"];
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
