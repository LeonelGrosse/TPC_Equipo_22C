using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class AccesoDatos
    {
        private SqlConnection Conexion;
        private SqlCommand Comando;
        private SqlDataReader Reader;
        public SqlDataReader Lector
        {
            get { return Reader; }
        }
        public AccesoDatos()
        {
            Conexion = new SqlConnection("server=.\\SQLEXPRESS; database=BAEventos ; integrated security = true"); //Falta poner la BD
            Comando = new SqlCommand();
        }
        public void setConsulta(string consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Reader = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ejecutarAccion()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EjecutarAccion()
        {
            Comando.Connection = Conexion;
            try
            {
                Conexion.Open();
                int filasAfectadas = Comando.ExecuteNonQuery();

                return (filasAfectadas > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ejecutarEscalar()
        {
            try
            {
                Conexion.Open();
                return (int)Comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.Close();
            }
        }
        public void setParametro(string nombre, object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);
        }
        
        public void SetStoredProcedure(string nombreProcedure)
        {
            Comando.CommandType = System.Data.CommandType.StoredProcedure;
            Comando.CommandText = nombreProcedure;
        }
        public void cerrarConexion()
        {
            if (Reader != null)
            {
                Reader.Close();
            }
            Conexion.Close();
        }
    }
}
