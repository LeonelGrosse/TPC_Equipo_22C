using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Ubicacion
    {
        public Ubicacion()
        {
            Ciudad = new Ciudad();
            Direccion = new Direccion();
        }
        public Ciudad Ciudad { get; set; }
        public Direccion Direccion { get; set; }
    }
}
