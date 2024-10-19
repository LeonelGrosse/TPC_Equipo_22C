using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class accesoDatos
    {
        private SqlConnection conexion;       
        private SqlCommand comando;             
        private SqlDataReader lector;           
        public SqlDataReader Lector             
        {
            get { return lector; }
        }

        public accesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database = ; integrated security = true"); //Falta poner la BD
            comando = new SqlCommand();
        }
        public void setConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;  
            comando.CommandText = consulta;                     
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery(); 
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
                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        public void setParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);      
        }
        public void cerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }
    }
}
