using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CiudadNegocio
    {
        private AccesoDatos Datos;
        private List<Ciudad> Ciudades;

        public CiudadNegocio()
        {
            Datos = new AccesoDatos();
            Ciudades = new List<Ciudad>();
        }
        public List<Ciudad> Listar()
        {
            AccesoDatos datosCiudad = new AccesoDatos();

            try
            {
                datosCiudad.setConsulta("select C.IdCiudad, IDProvincia, C.Nombre, P.Nombre from ciudad C inner join Provincia P on P.IDProvincia = C.IDPronvincia");
                datosCiudad.ejecutarLectura();

                while (datosCiudad.Lector.Read())
                {
                    Ciudad ciudad = new Ciudad();
                    ciudad.IdCiudad = (int)datosCiudad.Lector["C.IdCiudad"];
                    ciudad.Nombre = (string)datosCiudad.Lector["C.Nombre"];
                    ciudad.Provincia.ID= (int)datosCiudad.Lector["C.IDProvincia"];
                    ciudad.Provincia.Nombre = (string)datosCiudad.Lector["P.Nombre"];

                    Ciudades.Add(ciudad);
                }
                return Ciudades;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally { datosCiudad.cerrarConexion(); }
        }

       public List<Ciudad> ObtenerConStoredProcedure()
        {
            try
            {
                Datos.SetStoredProcedure("SP_OBTENER_CIUDADES");
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Ciudad ciudad = new Ciudad();
                    ciudad.IdCiudad = (int)(Int64)Datos.Lector["IDCiudad"];
                    ciudad.Nombre = (string)Datos.Lector["Ciudad"];
                    ciudad.Provincia.ID = (int)(Int64)Datos.Lector["IDProvincia"];
                    ciudad.Provincia.Nombre = (string)Datos.Lector["Provincia"];
                    Ciudades.Add(ciudad);
                }
                return Ciudades;
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

      /*  Hay que permitir al organizador agregar una ciudad inexistente?
       *  public bool Insertar(Ciudad ciudad)
        {
            AccesoDatos DB = new AccesoDatos();
            try
            {
                DB.setConsulta("INSERT INTO Ciudad(IDPais, Nombre)VALUES(@IDPais, @Nombre)");
                DB.setParametro("@IDPais", ciudad.Provincia.ID);
                DB.setParametro("@Nombre", ciudad.Nombre);

                return DB.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
    }
}
