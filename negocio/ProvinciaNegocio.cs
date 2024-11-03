using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ProvinciaNegocio
    {
        private AccesoDatos Datos;
        private List<Provincia> Provincias; 

        public ProvinciaNegocio()
        {
            Datos = new AccesoDatos();
            Provincias = new List<Provincia>();
        }

        public List<Provincia> ObtenerProvincias()
        {
            try
            {
                Datos.SetStoredProcedure("SP_OBTENER_PROVINCIAS");
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Provincia provincia = new Provincia();
                    provincia.ID = (int)(Int64)Datos.Lector["ID"];
                    provincia.Nombre = (string)Datos.Lector["Nombre"];

                    Provincias.Add(provincia);
                }

                return Provincias;
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

    }
}
