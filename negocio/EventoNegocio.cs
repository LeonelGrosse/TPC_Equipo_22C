using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using accesorio;
using dominio;
using static System.Net.Mime.MediaTypeNames;

namespace negocio
{
    public class EventoNegocio
    {
        List<Evento> Lista = new List<Evento>();
        AccesoDatos Datos = new AccesoDatos();

        public List<Evento> Listar(int idEvento = 0)
        {
            try
            {
                Datos.SetStoredProcedure("SP_LISTA_EVENTO");
                if (idEvento != 0)
                    Datos.setParametro("@IDEvento", idEvento);
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Evento aux = new Evento();
                    aux.IdEvento = (int)(Int64)Datos.Lector["IDEvento"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.FechaEvento = (DateTime)Datos.Lector["FechaEvento"];

                    aux.Ubicacion = new Ubicacion();
                    aux.Ubicacion.Ciudad.Nombre = (string)Datos.Lector["Ciudad"];
                    aux.Ubicacion.Ciudad.Provincia.ID = (int)(Int64)Datos.Lector["IDProvincia"];
                    aux.Ubicacion.Ciudad.Provincia.Nombre = (string)Datos.Lector["Provincia"];
                    aux.Ubicacion.Direccion.ID = (short)Datos.Lector["ID"];
                    aux.Ubicacion.Direccion.Calle = (string)Datos.Lector["Calle"];
                    aux.Ubicacion.Direccion.Altura = (string)Datos.Lector["Altura"];

                    aux.CostoInscripcion = (decimal)Datos.Lector["CostoInscripcion"];

                    aux.Estado = char.Parse(Datos.Lector["Estado"].ToString());
                    aux.EdadMinima = (int)(byte)Datos.Lector["EdadMinima"];
                    aux.EdadMaxima = (int)(byte)Datos.Lector["EdadMaxima"];
                    aux.CuposDisponibles = (int)Datos.Lector["CuposDisponibles"];

                    CargarDisciplinasDeEvento(aux);

                    if (!(Datos.Lector["ImgURL"] is DBNull))
                    {
                        aux.Imagen.URL = (string)Datos.Lector["ImgURL"];
                    }
                    else aux.Imagen.URL = "https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image-300x225.png";

                    Lista.Add(aux);
                }
                return Lista;
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
        public Evento BuscarPorID(int id)
        {
            string select = "Select e.IDEvento, e.Nombre, e.FechaEvento, e.CostoInscripcion, e.EdadMinima, e.CuposDisponibles, e.Estado,p.ID as IDProvincia, p.Nombre as Provincia, c.IDCiudad, c.Nombre as Ciudad, dire.ID, dire.Calle, dire.Altura,  d.IDDisciplina, d.Disciplina, ixe.IDImagen, ixe.ImgURL";
            string from = " FROM Evento e Inner join Disciplina_x_Evento de On de.IDEvento = e.IDEvento Inner join Disciplina d On d.IDDisciplina = de.IDDisciplina Inner join Imagen_x_Evento ixe On ixe.IDEvento = e.IDEvento Inner join Ubicacion u On u.IDUbicacion = e.Ubicacion Inner join Ciudad c On c.IDCiudad = u.IDCiudad Inner join Provincia p On p.ID = c.IDProvincia Inner join Direccion dire On dire.ID = u.IDDireccion Where e.Estado = 'D' and e.IDEvento = " + id + "";

            try
            {
                Datos.setConsulta(select + from);
                Datos.ejecutarLectura();

                Evento aux = new Evento();
                while (Datos.Lector.Read())
                {
                    aux.IdEvento = (int)(Int64)Datos.Lector["IDEvento"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.FechaEvento = (DateTime)Datos.Lector["FechaEvento"];

                    aux.Ubicacion = new Ubicacion();
                    aux.Ubicacion.Ciudad.Nombre = (string)Datos.Lector["Ciudad"];
                    aux.Ubicacion.Ciudad.Provincia.ID = (int)(Int64)Datos.Lector["IDProvincia"];
                    aux.Ubicacion.Ciudad.Provincia.Nombre = (string)Datos.Lector["Provincia"];
                    aux.Ubicacion.Direccion.ID = (short)Datos.Lector["ID"];
                    aux.Ubicacion.Direccion.Calle = (string)Datos.Lector["Calle"];
                    aux.Ubicacion.Direccion.Altura = (string)Datos.Lector["Altura"];

                    aux.CostoInscripcion = (decimal)Datos.Lector["CostoInscripcion"];

                    aux.Estado = char.Parse(Datos.Lector["Estado"].ToString());
                    aux.EdadMinima = (int)(byte)Datos.Lector["EdadMinima"];
                    aux.CuposDisponibles = (int)Datos.Lector["CuposDisponibles"];

                    CargarDisciplinasDeEvento(aux);

                    if (!(Datos.Lector["ImgURL"] is DBNull))
                    {
                        aux.Imagen.URL = (string)Datos.Lector["ImgURL"];
                    }
                    else aux.Imagen.URL = "https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image-300x225.png";
                }
                return aux;
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

        public void RegistrarEvento(Evento evento)
        {
            try
            {
                Datos.SetStoredProcedure("SP_INSERTAR_EVENTO");
                Datos.setParametro("@CALLE", evento.Ubicacion.Direccion.Calle);
                Datos.setParametro("@ALTURA", evento.Ubicacion.Direccion.Altura);
                Datos.setParametro("@ID_CIUDAD", evento.Ubicacion.Ciudad.IdCiudad);
                Datos.setParametro("@NOMBRE", evento.Nombre);
                Datos.setParametro("@FECHA", evento.FechaEvento);
                Datos.setParametro("@COSTO_INSCRIPCION", evento.CostoInscripcion);
                Datos.setParametro("@ESTADO", evento.Estado);
                Datos.setParametro("@EDAD_MINIMA", evento.EdadMinima);
                Datos.setParametro("@EDAD_MAXIMA", evento.EdadMaxima);
                Datos.setParametro("@CUPOS_DISPONIBLES", evento.CuposDisponibles);
                evento.IdEvento = Datos.ejecutarEscalar();
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

        public bool RegistrarDisciplina(int IDEvento, Disciplina disciplina)
        {
            try
            {
                Datos.LimpiarComando();
                Datos.setConsulta("INSERT INTO Disciplina_x_Evento(IDEvento, IDDisciplina, Distancia)VALUES(@ID_EVENTO, @ID_DISCIPLINA, @DISTANCIA)");
                Datos.setParametro("@ID_EVENTO", IDEvento);
                Datos.setParametro("@ID_DISCIPLINA", disciplina.ID);
                Datos.setParametro("@DISTANCIA", disciplina.Distancia);

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
        public void modificar(Evento evento)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Update Evento set Nombre = @nom, FechaEvento = @fecha, CostoInscripcion= @costo, EdadMinima = @edadMinima, EdadMaxima =  @edadMaxima, CuposDisponibles = @cupos where IDEvento = @id");
                datos.setParametro("@nom", evento.Nombre);
                datos.setParametro("@fecha", evento.FechaEvento);
                datos.setParametro("@costo", evento.CostoInscripcion);
                datos.setParametro("@edadMinima", evento.EdadMinima);
                datos.setParametro("@edadMaxima", evento.EdadMaxima);
                datos.setParametro("@cupos", evento.CuposDisponibles);
                datos.setParametro("@id", evento.IdEvento);

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

        // Puedo actualizar cualquier tipo de valor, incluyendo el estado y hacer una baja lógica.
        public bool ModificarEscalar<T>(string columna, int idEvento, T valor)
        {
            try
            {
                Datos.setConsulta($"UPDATE Evento SET {columna} = {valor} WHERE IDEvento = @idEvento");
                Datos.setParametro("@idEvento", idEvento);
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

        public void EliminarEvento(int id)
        {
            try
            {
                Datos.setConsulta("SP_ELIMINAR_EVENTO @ID");
                Datos.setParametro("@ID", id);
                Datos.ejecutarAccion();

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
        public void DarBajaEvento(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("Update Evento Set Estado = 'F' Where IDEvento = @id");
                datos.setParametro("@id", id);
                datos.ejecutarAccion();

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

        public void InscribirseEvento(int idEvento, int idUsuario)
        {
            try
            {
                Datos.LimpiarComando();
                Datos.setConsulta("INSERT INTO Usuario_x_Evento (IDEvento, IDUsuario) VALUES (@idEvento, @idUsuario)");
                Datos.setParametro("@idEvento", idEvento);
                Datos.setParametro("@idUsuario", idUsuario);
                Datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }

        public List<Evento> Filtrar(string campo, int criterio)
        {
            Filtro filtro = new Filtro();

            try
            {
                string query = "Select E.IDEvento, E.Nombre, E.FechaEvento, E.CostoInscripcion, E.EdadMinima, E.EdadMaxima, E.CuposDisponibles, E.Estado, P.ID as IDProvincia, P.Nombre as Provincia, C.IDCiudad, C.Nombre as Ciudad, Dir.ID, Dir.Calle, Dir.Altura, IxE.IDImagen, IxE.ImgURL FROM Evento AS E left join Imagen_x_Evento AS IxE On IxE.IDEvento = E.IDEvento Inner join Ubicacion AS U On U.IDUbicacion = E.Ubicacion Inner join Ciudad AS C On C.IDCiudad = u.IDCiudad Inner join Provincia AS P On P.ID = C.IDProvincia Inner join Direccion AS Dir On Dir.ID = U.IDDireccion Where E.Estado = 'D'"
;
                filtro.SetearQueryBase(query);
                filtro.AplicarCriterioAQuery(campo, criterio);

                Datos.setConsulta(filtro.query);
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Evento aux = new Evento();
                    aux.IdEvento = (int)(Int64)Datos.Lector["IDEvento"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.FechaEvento = (DateTime)Datos.Lector["FechaEvento"];

                    aux.Ubicacion = new Ubicacion();
                    aux.Ubicacion.Ciudad.Nombre = (string)Datos.Lector["Ciudad"];
                    aux.Ubicacion.Ciudad.Provincia.ID = (int)(Int64)Datos.Lector["IDProvincia"];
                    aux.Ubicacion.Ciudad.Provincia.Nombre = (string)Datos.Lector["Provincia"];
                    aux.Ubicacion.Direccion.ID = (short)Datos.Lector["ID"];
                    aux.Ubicacion.Direccion.Calle = (string)Datos.Lector["Calle"];
                    aux.Ubicacion.Direccion.Altura = (string)Datos.Lector["Altura"];

                    aux.CostoInscripcion = (decimal)Datos.Lector["CostoInscripcion"];

                    aux.Estado = char.Parse(Datos.Lector["Estado"].ToString());
                    aux.EdadMinima = (int)(byte)Datos.Lector["EdadMinima"];
                    aux.EdadMaxima = (int)(byte)Datos.Lector["EdadMaxima"];
                    aux.CuposDisponibles = (int)Datos.Lector["CuposDisponibles"];

                    CargarDisciplinasDeEvento(aux);

                    if (!(Datos.Lector["ImgURL"] is DBNull))
                    {
                        aux.Imagen.URL = (string)Datos.Lector["ImgURL"];
                    }
                    else aux.Imagen.URL = "https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image-300x225.png";

                    Lista.Add(aux);
                }

                return Lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }

        public List<string> ObtenerUsuariosInscriptos(int idEvento)
        {
            List<string> ListadoDNI = new List<string>(); 
            try
            {
                Datos.LimpiarComando();
                Datos.SetStoredProcedure("OBTENER_USUARIOS_INSCRIPTOS");
                Datos.setParametro("@IDEVENTO", idEvento);
                Datos.ejecutarLectura();

                while (Datos.Lector.Read()) 
                {
                    string dni = (string)Datos.Lector["DNI"];
                    ListadoDNI.Add(dni);
                }

                return ListadoDNI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }
    }
}
