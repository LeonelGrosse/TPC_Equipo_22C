using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                DB.setConsulta("SELECT Us.IDUsuario, Us.Nombre, Us.Apellido, Us.DNI, US.CorreoElectronico, US.Contrasena, US.FechaNacimiento ,DATEDIFF(YEAR, US.FechaNacimiento, GETDATE()) AS Edad, R.IDRol, R.Rol FROM Usuario AS Us INNER JOIN Rol AS R ON Us.IDrol = R.IDRol");
                DB.ejecutarLectura();

                while (DB.Lector.Read())
                {
                    Usuario Usuario = new Usuario();
                    Usuario.IdUsuario = (int)(Int64)DB.Lector["IDUsuario"];
                    Usuario.Nombre = (string)DB.Lector["Nombre"];
                    Usuario.Apellido = (string)DB.Lector["Apellido"];
                    Usuario.Dni = (string)DB.Lector["DNI"];
                    Usuario.CorreoElectronico = (string)DB.Lector["CorreoElectronico"];
                    Usuario.FechaNacimiento = (DateTime)DB.Lector["FechaNacimiento"];
                    Usuario.Contrasenia = (string)DB.Lector["Contrasena"];
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
        public void agregar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Insert into Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, Estado) Values (@idRol, @contra, @apellido, @nombre, @dni, @correo, @fechaNacimiento, " + 1 + ")");
                datos.setParametro("@idRol", nuevo.Rol.IdRol);
                datos.setParametro("@contra", nuevo.Contrasenia);
                datos.setParametro("@apellido", nuevo.Apellido);
                datos.setParametro("@nombre", nuevo.Nombre);
                datos.setParametro("@dni", nuevo.Dni);
                datos.setParametro("@correo", nuevo.CorreoElectronico);
                datos.setParametro("@fechaNacimiento", nuevo.FechaNacimiento);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("update Usuario set Apellido = @apellido, Nombre = @nombre, DNI = @dni, CorreoElectronico = @correo, FechaNacimiento = @fechaNacimiento where IDUsuario = @id");
                datos.setParametro("@apellido", usuario.Apellido);
                datos.setParametro("@nombre", usuario.Nombre);
                datos.setParametro("@dni", usuario.Dni);
                datos.setParametro("@correo", usuario.CorreoElectronico);
                datos.setParametro("@fechaNacimiento", usuario.FechaNacimiento);
                datos.setParametro("@id", usuario.IdUsuario);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("delete from Usuario where IDUsuario = @id");
                datos.setParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool checkUsuario(int dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select dni from Usuario where dni = @dni"); /*comparar @dni con dni de DB*/
                datos.setParametro("@dni", dni);
                datos.ejecutarLectura();

                if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("dni")))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al verificar el DNI: " + ex.Message);
            }

            finally { datos.cerrarConexion(); }

            return true;
        }

        public bool checkLogin(string email, string pass)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select CorreoElectronico from Usuario where CorreoElectronico = @email"); /*comparar @email con email de DB*/
                datos.setParametro("@email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {

                    if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("CorreoElectronico")))

                    {

                        try
                        {
                            datos.cerrarConexion();
                            datos.abrirConexion();

                            datos.setConsulta("select contrasena from usuario where contrasena = @pass"); /*comparar @pass con contraseña de DB*/
                            datos.setParametro("@pass", pass);
                            datos.ejecutarLectura();

                            if (datos.Lector.Read())
                            {

                                if (!datos.Lector.IsDBNull(datos.Lector.GetOrdinal("contrasena")))
                                {
                                    return true;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("Error al verificar el Email: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al verificar el Email: " + ex.Message);
            }

            finally { datos.cerrarConexion(); }

            return false;
        }
    }
}
