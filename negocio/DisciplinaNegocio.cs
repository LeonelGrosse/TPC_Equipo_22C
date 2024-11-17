using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
	public class DisciplinaNegocio
	{
		private AccesoDatos Datos;

		public DisciplinaNegocio()
		{ 
			Datos = new AccesoDatos();
		}
		public List<Disciplina> Listar()
		{
			List<Disciplina> listaDisciplina = new List<Disciplina>();

			try
			{
				Datos.setConsulta("select IDDisciplina, disciplina from Disciplina");
				Datos.ejecutarLectura();

				while (Datos.Lector.Read())
				{
					Disciplina disciplina = new Disciplina();
					disciplina.IdDisciplina = (int)(Int64)Datos.Lector["IDDisciplina"];
					disciplina.Descripcion = (string)Datos.Lector["disciplina"];

					listaDisciplina.Add(disciplina);
				}

				return listaDisciplina;
			}
			catch (Exception ex)
			{
				throw ex;
			}

			finally { Datos.cerrarConexion(); }
		}

		public List<Disciplina> ListarPorEvento(int id)
		{
			List<Disciplina> listDisciplina = new List<Disciplina>();

			try
			{
                Datos.setConsulta("SELECT d.IDDisciplina, d.Disciplina FROM Disciplina d INNER JOIN Disciplina_x_Evento de ON de.IDDisciplina = d.IDDisciplina INNER JOIN Evento e ON e.IDEvento = de.IDEvento WHERE e.IDEvento = @idEvento");
				Datos.setParametro("@idEvento", id);
                Datos.ejecutarLectura();

                while (Datos.Lector.Read())
                {
                    Disciplina disciplina = new Disciplina();
                    disciplina.IdDisciplina = (int)(Int64)Datos.Lector["IDDisciplina"];
                    disciplina.Descripcion = (string)Datos.Lector["Disciplina"];

                    listDisciplina.Add(disciplina);
                }

                return listDisciplina;
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
	}
}
