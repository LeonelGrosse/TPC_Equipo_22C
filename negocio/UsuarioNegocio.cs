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

            DB.LimpiarComando();
            try
            {
                DB.setConsulta("Insert into Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, Estado) Values (@idRol, @contra, @apellido, @nombre, @dni, @correo, @fechaNacimiento, " + 1 + ")");
                DB.setParametro("@idRol", nuevo.Rol.IdRol);
                DB.setParametro("@contra", nuevo.Contrasenia);
                DB.setParametro("@apellido", nuevo.Apellido);
                DB.setParametro("@nombre", nuevo.Nombre);
                DB.setParametro("@dni", nuevo.Dni);
                DB.setParametro("@correo", nuevo.CorreoElectronico);
                DB.setParametro("@fechaNacimiento", nuevo.FechaNacimiento);
                DB.ejecutarAccion();
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

        public void modificar(Usuario usuario)
        {
           
            try
            {
                DB.setConsulta("update Usuario set Apellido = @apellido, Nombre = @nombre, DNI = @dni, CorreoElectronico = @correo, FechaNacimiento = @fechaNacimiento where IDUsuario = @id");
                DB.setParametro("@apellido", usuario.Apellido);
                DB.setParametro("@nombre", usuario.Nombre);
                DB.setParametro("@dni", usuario.Dni);
                DB.setParametro("@correo", usuario.CorreoElectronico);
                DB.setParametro("@fechaNacimiento", usuario.FechaNacimiento);
                DB.setParametro("@id", usuario.IdUsuario);

                DB.ejecutarAccion();
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

        public void eliminar(int id)
        {
            try
            {

                DB.setConsulta("delete from Usuario where IDUsuario = @id");
                DB.setParametro("@id", id);
                DB.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Usuario cargar(string email)
        {
            try
            {
                DB.setConsulta("SELECT Us.IDUsuario, Us.Nombre, Us.Apellido, Us.DNI, US.CorreoElectronico, US.Contrasena, US.FechaNacimiento ,DATEDIFF(YEAR, US.FechaNacimiento, GETDATE()) \r\nAS Edad, R.IDRol, R.Rol FROM Usuario AS Us INNER JOIN Rol AS R ON Us.IDrol = R.IDRol\r\nWHERE US.CorreoElectronico = @email");
                DB.setParametro("@email", email);
                DB.ejecutarLectura();

                Usuario Usuario = new Usuario();

                if (DB.Lector.Read())
                {
                    
                    Usuario.IdUsuario = (int)(Int64)DB.Lector["IDUsuario"];
                    Usuario.Nombre = (string)DB.Lector["Nombre"];
                    Usuario.Apellido = (string)DB.Lector["Apellido"];
                    Usuario.Dni = (string)DB.Lector["DNI"];
                    Usuario.CorreoElectronico = (string)DB.Lector["CorreoElectronico"];
                    Usuario.FechaNacimiento = (DateTime)DB.Lector["FechaNacimiento"];
                    Usuario.Contrasenia = (string)DB.Lector["Contrasena"];
                    Usuario.Rol.IdRol = (Int16)DB.Lector["IDRol"];
                    Usuario.Rol.Descripcion = (string)DB.Lector["Rol"];

                    
                }

                return Usuario;
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
    

        public bool checkUsuario(int dni)
        {
            
            try
            {
                DB.setConsulta("select dni from Usuario where dni = @dni"); /*comparar @dni con dni de DB*/
                DB.setParametro("@dni", dni);
                DB.ejecutarLectura();

                if (!DB.Lector.IsDBNull(DB.Lector.GetOrdinal("dni")))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al verificar el DNI: " + ex.Message);
            }

            finally { DB.cerrarConexion(); }

            return true;
        }

        public bool checkLogin(string email, string pass)
        {

            try
            {
                DB.setConsulta("select CorreoElectronico from Usuario where CorreoElectronico = @email"); /*comparar @email con email de DB*/
                DB.setParametro("@email", email);
                DB.ejecutarLectura();

                if (DB.Lector.Read())
                {

                    if (!DB.Lector.IsDBNull(DB.Lector.GetOrdinal("CorreoElectronico")))

                    {

                        try
                        {
                            DB.cerrarConexion();
                            DB.abrirConexion();

                            DB.setConsulta("select contrasena from usuario where contrasena = @pass"); /*comparar @pass con contraseña de DB*/
                            DB.setParametro("@pass", pass);
                            DB.ejecutarLectura();

                            if (DB.Lector.Read())
                            {

                                if (!DB.Lector.IsDBNull(DB.Lector.GetOrdinal("contrasena")))
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

            finally { DB.cerrarConexion(); }

            return false;
        }
    }
}

