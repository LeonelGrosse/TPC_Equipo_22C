using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ImagenNegocio
    {
        AccesoDatos Datos;

        public ImagenNegocio()
        {
            Datos = new AccesoDatos();
        }
        public int AsociarEvento(int IDEvento, string url)
        {
            try
            {
                Datos.setConsulta("INSERT INTO Imagen_x_Evento(IDEvento, ImgUrl)values(@IDEvento, @ImgUrl)");
                Datos.setParametro("@IDEvento", IDEvento);
                Datos.setParametro("@ImgUrl", url);
                return Datos.ejecutarEscalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modificar(int IDImagen, string URL)
        {
            try
            {
                Datos.setConsulta("UPDATE Imagen SET ImgUrl = @URL WHERE ID = @IDImagen");
                Datos.setParametro("@IDImagen", URL);
                Datos.setParametro("@URL", URL);
                return Datos.EjecutarAccion();
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
