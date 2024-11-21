using dominio;
using accesorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
        public List<Usuario> ListarPorEvento(int evento)
        {
            try
            {
                DB.setConsulta("Select u.IDUsuario, u.IDRol, r.Rol, u.Contrasena, u.Apellido, u.Nombre, u.DNI, u.CorreoElectronico, u.FechaNacimiento, u.Estado From Usuario_x_Evento ue Inner join Usuario u ON u.IDUsuario = ue.IDUsuario Join Rol r On r.IDRol = u.IDRol Where ue.IDEvento = @idEvento");
                DB.setParametro("idEvento", evento);
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
        public int agregar(Usuario nuevo)
        {
            DB.LimpiarComando();
            try
            {
                DB.setConsulta("Insert into Usuario (IDRol, Contrasena, Apellido, Nombre, DNI, CorreoElectronico, FechaNacimiento, Estado) Values (@idRol, @contra, @apellido, @nombre, @dni, @correo, @fechaNacimiento, " + 1 + ");SELECT CAST(SCOPE_IDENTITY() AS INT);");
                DB.setParametro("@idRol", nuevo.Rol.IdRol);
                DB.setParametro("@contra", nuevo.Contrasenia);
                DB.setParametro("@apellido", nuevo.Apellido);
                DB.setParametro("@nombre", nuevo.Nombre);
                DB.setParametro("@dni", nuevo.Dni);
                DB.setParametro("@correo", nuevo.CorreoElectronico);
                DB.setParametro("@fechaNacimiento", nuevo.FechaNacimiento);
                //DB.ejecutarAccion();

                int idGenerado = (int)DB.ejecutarEscalar();
                return idGenerado;


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
        public bool ModificarEscalar<T>(string columna, int idUsuario, T valor)
        {
            try
            {
                DB.LimpiarComando();
                DB.setConsulta($"UPDATE Usuario SET {columna} = '{valor}' WHERE IDUsuario = @idUsuario");
                DB.setParametro("@idUsuario", idUsuario);
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
            finally
            {
                DB.cerrarConexion();
            }

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

        public bool Login(Usuario usuario, string correo, string password)
        {
            try
            {
                DB.LimpiarComando();
                DB.SetStoredProcedure("SP_OBTENER_REGISTRO_USUARIO");
                DB.setParametro("@EMAIL", correo);
                DB.setParametro("@PASSWORD", password);
                DB.ejecutarLectura();

                if (DB.Lector.Read())
                {
                    usuario.IdUsuario = (int)(Int64)DB.Lector["IDUsuario"];
                    usuario.Nombre = (string)DB.Lector["Nombre"];
                    usuario.Apellido = (string)DB.Lector["Apellido"];
                    usuario.Dni = (string)DB.Lector["DNI"];
                    usuario.CorreoElectronico = correo;
                    usuario.FechaNacimiento = (DateTime)DB.Lector["FechaNacimiento"];
                    usuario.Contrasenia = password;
                    usuario.Rol.IdRol = (int)(Int16)DB.Lector["IDRol"];
                    usuario.Imagen.ID = !DB.Lector.IsDBNull(DB.Lector.GetOrdinal("IDImagen")) ? (int)(Int16)DB.Lector["IDImagen"] : 0;
                    usuario.Imagen.URL = usuario.Imagen.ID != 0 ? (string)DB.Lector["ImgURL"] : "";
                    return true;
                }
                return false;
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

        public bool checkRecuperacion(string email, string dni)
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

                            DB.setConsulta("select DNI from usuario where DNI = @dni"); /*comparar @dni con DNI de DB*/
                            DB.setParametro("@dni", dni);
                            DB.ejecutarLectura();

                            if (DB.Lector.Read())
                            {

                                if (!DB.Lector.IsDBNull(DB.Lector.GetOrdinal("DNI")))
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

        public bool RecuperarContrasenia(string pass, string email)
        {
            try
            {
                DB.setConsulta("UPDATE usuario SET contrasena = @pass WHERE CorreoElectronico = @email ");
                DB.setParametro("@pass", pass);
                DB.setParametro("@email", email);
                DB.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al reestablecer contraseña: " + ex.Message);
            }
            finally
            {
                DB.cerrarConexion();
            }
            return false;
        }

        public void cargarImagen(Usuario usuario,  int id)
        {


            try
            {
                DB.setConsulta("INSERT INTO Imagen_x_Usuario (IDUsuario, ImgUrl)\r\nVALUES (@id, @urlimagen);");
                DB.setParametro("@id", id);
                DB.setParametro("@urlimagen", usuario.Imagen.URL);
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

        public List<Evento> ListarEventos(int idUsuario)
        {
            try
            {
                List<Evento> listaEventos = new List<Evento>();

                DB.SetStoredProcedure("OBTENER_EVENTOS_USUARIO");
                DB.setParametro("@IDUSUARIO", idUsuario);

                DB.ejecutarLectura();
                while (DB.Lector.Read())
                {
                    Evento aux = new Evento();
                    aux.IdEvento = (int)(Int64)DB.Lector["IDEvento"];
                    aux.Nombre = (string)DB.Lector["Nombre"];
                    aux.FechaEvento = (DateTime)DB.Lector["FechaEvento"];

                    aux.Ubicacion = new Ubicacion();
                    aux.Ubicacion.Ciudad.Nombre = (string)DB.Lector["NombreCiudad"];
                    aux.Ubicacion.Ciudad.Provincia.ID = (int)(Int64)DB.Lector["IDProvincia"];
                    aux.Ubicacion.Ciudad.Provincia.Nombre = (string)DB.Lector["NombreProvincia"];
                    aux.Ubicacion.Direccion.Calle = (string)DB.Lector["Calle"];
                    aux.Ubicacion.Direccion.Altura = (string)DB.Lector["Altura"];
                    aux.CostoInscripcion = Decimal.Round((decimal)DB.Lector["CostoInscripcion"]);
                    aux.Estado = char.Parse(DB.Lector["Estado"].ToString());
                    aux.EdadMinima = (int)(byte)DB.Lector["EdadMinima"];
                    aux.EdadMaxima = (int)(byte)DB.Lector["EdadMaxima"];
                    aux.CuposDisponibles = (int)DB.Lector["CuposDisponibles"];
                    CargarDisciplinasDeEvento(aux);

                    if (!(DB.Lector["ImgUrl"] is DBNull))
                        aux.Imagen.URL = (string)DB.Lector["ImgUrl"];

                    listaEventos.Add(aux);
                }

                return listaEventos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                DB.cerrarConexion();
            }
        }

        private void CargarDisciplinasDeEvento(Evento evento)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetStoredProcedure("SP_DISCPLINAS_X_EVENTO");
                datos.setParametro("@IDEVENTO", evento.IdEvento);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Disciplina auxiliarDisciplina = new Disciplina();
                    auxiliarDisciplina.ID = (int)(Int64)datos.Lector["IDDisciplina"];
                    auxiliarDisciplina.Nombre = (string)datos.Lector["Disciplina"];
                    auxiliarDisciplina.Distancia = (decimal)datos.Lector["Distancia"];

                    evento.Disciplina.Add(auxiliarDisciplina);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool CancelarInscripcion(int idEvento, int idUsuario)
        {
            try
            {
                DB.setConsulta($"DELETE FROM Usuario_x_Evento WHERE IDEvento = {idEvento} AND IDUsuario = {idUsuario}");
                return DB.EjecutarAccion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                DB.cerrarConexion();
            }
        }

        public int tomarId(string dni)
        {
            try
            {
                DB.setConsulta("select IDUsuario from Usuario where DNI = @identificacion");
                DB.setParametro("@identificacion", dni);
                DB.ejecutarLectura();

                if (DB.Lector.Read())
                {

                    try
                    {
                        int idTomado = (int)DB.Lector["IDUsuario"];
                        return idTomado;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al verificar el Email: " + ex.Message);
                    }
                    finally
                    {
                        DB.cerrarConexion();
                    }


                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally { DB.cerrarConexion(); }

        }



        public List<Evento> Filtrar(string campo, int criterio, int idUsuario)
        {
            List<Evento> listaEventos = new List<Evento>();
            Filtro filtro = new Filtro();
            try
            {
                string query = " SELECT  E.IDEvento, E.Nombre, E.FechaEvento, E.CostoInscripcion, E.CuposDisponibles, E.EdadMinima, E.EdadMaxima, E.Estado, C.Nombre AS NombreCiudad, P.ID AS IDProvincia, P.Nombre AS NombreProvincia, D.Calle,  D.Altura, IxE.ImgUrl FROM  Evento AS E  INNER JOIN  Usuario_x_Evento AS UxE  ON E.IDEvento = UxE.IDEvento INNER JOIN  Ubicacion AS U ON E.Ubicacion = U.IDUbicacion INNER JOIN  Ciudad AS C ON C.IDCiudad = U.IDCiudad INNER JOIN Provincia AS P ON P.ID = U.IDCiudad INNER JOIN  Direccion AS D ON D.ID = U.IDDireccion LEFT JOIN  Imagen_x_Evento AS IxE ON IxE.IDEvento = E.IDEvento WHERE UxE.IDUsuario = @IDUSUARIO";

                filtro.SetearQueryBase(query);
                filtro.AplicarCriterioAQuery(campo, criterio);

                DB.setConsulta(filtro.query);
                DB.setParametro("@IDUSUARIO", idUsuario);
                DB.ejecutarLectura();

                while (DB.Lector.Read())
                {
                    Evento eventoAuxiliar = new Evento();
                    eventoAuxiliar.IdEvento = (int)(Int64)DB.Lector["IDEvento"];
                    eventoAuxiliar.Nombre = (string)DB.Lector["Nombre"];
                    eventoAuxiliar.FechaEvento = (DateTime)DB.Lector["FechaEvento"];

                    eventoAuxiliar.Ubicacion = new Ubicacion();
                    eventoAuxiliar.Ubicacion.Ciudad.Nombre = (string)DB.Lector["NombreCiudad"];
                    eventoAuxiliar.Ubicacion.Ciudad.Provincia.ID = (int)(Int64)DB.Lector["IDProvincia"];
                    eventoAuxiliar.Ubicacion.Ciudad.Provincia.Nombre = (string)DB.Lector["NombreProvincia"];
                    eventoAuxiliar.Ubicacion.Direccion.Calle = (string)DB.Lector["Calle"];
                    eventoAuxiliar.Ubicacion.Direccion.Altura = (string)DB.Lector["Altura"];
                    eventoAuxiliar.CostoInscripcion = Decimal.Round((decimal)DB.Lector["CostoInscripcion"]);
                    eventoAuxiliar.Estado = char.Parse(DB.Lector["Estado"].ToString());
                    eventoAuxiliar.EdadMinima = (int)(byte)DB.Lector["EdadMinima"];
                    eventoAuxiliar.EdadMaxima = (int)(byte)DB.Lector["EdadMaxima"];
                    eventoAuxiliar.CuposDisponibles = (int)DB.Lector["CuposDisponibles"];
                    CargarDisciplinasDeEvento(eventoAuxiliar);

                    if (!(DB.Lector["ImgUrl"] is DBNull))
                        eventoAuxiliar.Imagen.URL = (string)DB.Lector["ImgUrl"];

                    listaEventos.Add(eventoAuxiliar);
                }

                return listaEventos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                DB.cerrarConexion();
            }
        }
    }
}
