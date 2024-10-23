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
		public List<Disciplina> Listar()
		{
			List<Disciplina> listaDisciplina = new List<Disciplina>();
			AccesoDatos datosDisciplina = new AccesoDatos();

			try
			{
				datosDisciplina.setConsulta("select IDDisciplina, disciplina from Disciplina");
				datosDisciplina.ejecutarLectura();

				while (datosDisciplina.Lector.Read())
				{
					Disciplina disciplina = new Disciplina();
					disciplina.IdDisciplina = (int)datosDisciplina.Lector["IDDisciplina"];
					disciplina.Descripcion = (string)datosDisciplina.Lector["disciplina"];

					listaDisciplina.Add(disciplina);
				}

				return listaDisciplina;

			}
			catch (Exception ex)
			{

				throw ex;
			}

			finally { datosDisciplina.cerrarConexion(); }
		}
	}
}
