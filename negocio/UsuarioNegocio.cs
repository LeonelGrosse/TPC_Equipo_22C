using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        private AccesoDatos DB;
        private Usuario Usuario;
        List<Usuario> Usuarios;
        public UsuarioNegocio()
        {
            DB = new AccesoDatos();
            Usuario = new Usuario();
            Usuarios = new List<Usuario>();
        }
        public List<Usuario> Listar()
        {
            try
            {
                DB.setConsulta("SELECT Us.IDUsuario, Us.Nombre, Us.Apellido, Us.DNI, US.CorreoElectronico, US.Contrasenia, US.FechaNacimiento ,DATEDIFF(YEAR, US.FechaNacimiento, GETDATE()) AS Edad, R.IDRol, R.Rol FROM Usuario AS Us INNER JOIN Rol AS R ON Us.IDrol = R.IDRol");
                DB.ejecutarLectura();

                while (DB.Lector.Read())
                {
                    Usuario.IdUsuario = (int)(Int64)DB.Lector["IDUsuario"];
                    Usuario.Nombre = (string)DB.Lector["Nombre"];
                    Usuario.Apellido = (string)DB.Lector["Apellido"];
                    Usuario.Dni = (string)DB.Lector["DNI"];
                    Usuario.CorreoElectronico = (string)DB.Lector["CorreoElectronico"];
                    Usuario.FechaNacimiento = (DateTime)DB.Lector["FechaNacimiento"];
                    Usuario.Contrasenia = (string)DB.Lector["Contrasenia"];
                    Usuario.Rol.IdRol = (Int16)DB.Lector["IDRol"];
                    Usuario.Rol.Descripcion = (string)DB.Lector["Rol"];

                    Usuarios.Add(Usuario);
                }
                return Usuarios;
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
