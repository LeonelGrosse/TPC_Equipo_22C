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
        public Ciudad()
        {
            Provincia = new Provincia();
        }
        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public Provincia Provincia { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
