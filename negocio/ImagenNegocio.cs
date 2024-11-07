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

        public int Insertar(string URL)
        {
            try
            {
                Datos.setConsulta("INSERT INTO Imagen(ImgUrl)VALUES(@URL)SELECT SCOPE_IDENTITY()");
                Datos.setParametro("@URL", URL);
                return Datos.ejecutarEscalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AsociarEvento(int IDImagen, int IDEvento)
        {
            try
            {
                Datos.setConsulta("INSERT INTO Imagen_x_Evento(IDImagen, IDEvento)values(@IDImagen, @IDEvento)");
                Datos.setParametro("@IDImagen", IDImagen);
                Datos.setParametro("@IDEvento", IDEvento);
                return Datos.EjecutarAccion();
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
