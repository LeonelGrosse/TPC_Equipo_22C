using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using accesorio;
using negocio;

namespace TPC
{
    public partial class Participantes : System.Web.UI.Page
    {
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        List<Usuario> usuarios = new List<Usuario>();   
        protected void Page_Load(object sender, EventArgs e)
        {
            int idEvento = int.Parse(Request.Params["IdEvento"].ToString());
            usuarios =usuarioNegocio.ListarPorEvento(idEvento);
            CargarGridView();
        }
        private void CargarGridView()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.AddRange(new DataColumn[] {
                new DataColumn("Nombre",typeof(string)),
                new DataColumn("Apellido",typeof(string)),
                new DataColumn("Dni",typeof(string)),
                new DataColumn("FechaNacimiento",typeof(DateTime)),
                new DataColumn("CorreoElectronico",typeof(string)),
            });
            if (usuarios.Count > 0)
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    tabla.Rows.Add(
                        usuarios[i].Nombre,
                        usuarios[i].Apellido,
                        usuarios[i].Dni,
                        usuarios[i].FechaNacimiento,
                        usuarios[i].CorreoElectronico
                        );
                }
            }
            gvParticipantes.DataSource = tabla;
            gvParticipantes.DataBind();
        }

        protected void btnEliminarDeEvento_Click(object sender, EventArgs e)
        {

        }
    }

}