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
        public List<Ciudad> Listar()
        {
            List<Ciudad> listaCiudad = new List<Ciudad>();
            AccesoDatos datosCiudad = new AccesoDatos();

            try
            {
                datosCiudad.setConsulta("select C.IdCiudad, C.IDPais, C.Nombre, P.Nombre from ciudad C inner join Pais P on P.IDPais = C.IDPais");
                datosCiudad.ejecutarLectura();

                while (datosCiudad.Lector.Read())
                {
                    Ciudad ciudad = new Ciudad();
                    ciudad.IdCiudad = (int)datosCiudad.Lector["C.IdCiudad"];
                    ciudad.Nombre = (string)datosCiudad.Lector["C.Nombre"];
                    ciudad.Pais = new Pais();
                    ciudad.Pais.IdPais = (int)datosCiudad.Lector["C.IDPais"];
                    ciudad.Pais.Nombre = (string)datosCiudad.Lector["P.Nombre"];

                    listaCiudad.Add(ciudad);
                }

                return listaCiudad;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally { datosCiudad.cerrarConexion(); }
        }
    }
}
