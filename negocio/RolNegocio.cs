using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class RolNegocio
    {
        private AccesoDatos DB;
        private Rol Rol;
        private List<Rol> Roles;
        public RolNegocio()
        {
            DB = new AccesoDatos();
            Roles = new List<Rol>();
            Rol = new Rol();
        }
        public List<Rol> Listar()
        {
            try
            {
                DB.setConsulta("SELECT IDRol,Rol FROM Rol");
                DB.ejecutarLectura();
                while (DB.Lector.Read())
                {
                    Rol.IdRol = (Int16)DB.Lector["IDRol"]; // Modificar el tipo en Db.
                    Rol.Descripcion = (string)DB.Lector["Rol"];
                    this.Roles.Add(Rol);
                }
                return this.Roles;
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
    }
}
