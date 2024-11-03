using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class DireccionNegocio
    {
        private AccesoDatos DB;

        public DireccionNegocio()
        {
            DB = new AccesoDatos();
        }
        public bool Insertar(Direccion direccion)
        {
            try
            {
                DB.setConsulta("INSERT INTO Direccion(Calle, Altura)VALUES(@Calle, @Altura)"); // CP deberia estar en otra tabla.
                DB.setParametro("@Calle", direccion.Calle);
                DB.setParametro("@Altura", direccion.Altura);

                if (CampoExiste(direccion.Calle, "Calle"))
                    return false;
                if (CampoExiste(direccion.Altura, "Altura"))
                    return false;

                return DB.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DB.cerrarConexion();
            }
        }

        public bool CampoExiste(string campoValor, string nombreColumna)
        {
            AccesoDatos consulta = new AccesoDatos();
            try
            {
                consulta.setConsulta($"SELECT ID FROM Direccion WHERE {nombreColumna} = '{campoValor}'");
                consulta.ejecutarLectura();

                return consulta.Lector.Read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                consulta.cerrarConexion();
            }
        }
    }
}
