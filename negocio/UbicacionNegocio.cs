using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class UbicacionNegocio
    {
		private AccesoDatos Datos;

		public UbicacionNegocio()
		{
			Datos = new AccesoDatos();
		}
        public bool ModificarDireccion() {
			try
			{
				return true;
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

		public bool ModificarCiudad()
		{
			try
			{
				return true;
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

        public bool ModificarProvincia()
        {
            try
            {
                return true;
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

		public bool BajaLogicaCiudad()
		{
			try
			{
				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public bool BajaLogicaPais()
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
