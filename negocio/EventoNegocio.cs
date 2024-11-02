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
        List<Evento> lista = new List<Evento>();
        AccesoDatos datos = new AccesoDatos();

        public List<Evento> listar()
        {
            string select = "Select e.IDEvento, e.Nombre, e.FechaEvento, e.CostoInscripcion, e.EdadMinima, e.CuposDisponibles, e.Estado, p.IDPais, p.Nombre as Pais, c.IDCiudad, c.Nombre as Ciudad, dire.ID, dire.Calle, dire.Altura, dire.CodigoPostal, d.IDDisciplina, d.Disciplina, i.ID, i.ImgURL ";
            string from = "from Evento e Inner join Disciplina_x_Evento de On de.IDEvento = e.IDEvento Inner join Disciplina d On d.IDDisciplina = de.IDDisciplina Inner join Imagen_x_Evento ie On ie.IDEvento = e.IDEvento Inner join Imagen i On i.ID = ie.IDImagen Inner join Ubicacion u On u.IDUbicacion = e.Ubicacion Inner join Ciudad c On c.IDCiudad = u.IDCiudad Inner join Pais p On p.IDPais = c.IDPais Inner join Direccion dire On dire.ID = u.IDDireccion Where e.Estado = 'D'";
            
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
                    aux.Ubicacion.Ciudad = new Ciudad();
                    aux.Ubicacion.Ciudad.Pais = new Pais();
                    aux.Ubicacion.Direccion = new Direccion();
                    aux.Ubicacion.Ciudad.IdCiudad = (int)(Int64)datos.Lector["IDCiudad"];
                    aux.Ubicacion.Ciudad.Nombre = (string)datos.Lector["Ciudad"];
                    aux.Ubicacion.Ciudad.Pais.IdPais = (int)(Int64)datos.Lector["IDPais"];
                    aux.Ubicacion.Ciudad.Pais.Nombre = (string)datos.Lector["Pais"];
                    aux.Ubicacion.Direccion.ID = (short)datos.Lector["ID"];
                    aux.Ubicacion.Direccion.Calle = (string)datos.Lector["Calle"];
                    aux.Ubicacion.Direccion.Altura = (string)datos.Lector["Altura"];
                    aux.Ubicacion.Direccion.CodigoPostal = (string)datos.Lector["CodigoPostal"];

                    aux.CostoInscripcion = (decimal)datos.Lector["CostoInscripcion"];

                    aux.Estado = (string)datos.Lector["Estado"];
                    aux.EdadMinima = (byte)datos.Lector["EdadMinima"];
                    aux.CuposDisponibles = (int)datos.Lector["CuposDisponibles"];

                    aux.Disciplina = new Disciplina();
                    aux.Disciplina.IdDisciplina = (int)(Int64)datos.Lector["IDDisciplina"];
                    aux.Disciplina.Descripcion = (string)datos.Lector["Disciplina"];

                    aux.Imagen = new Imagen();
                    if (!(datos.Lector["ImgURL"] is DBNull))
                    {
                        aux.Imagen.ID = (short)datos.Lector["ID"];
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
