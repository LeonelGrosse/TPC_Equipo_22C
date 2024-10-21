using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace dominio
{
    public class Ciudad
    {
        public int idCiudad { get; set; }
        public string nombre { get; set; }
        public Pais idPais { get; set; }
        public override string ToString()
        {
            return nombre;
        }
    }
}
