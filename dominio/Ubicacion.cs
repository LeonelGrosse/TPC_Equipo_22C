using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Ubicacion
    {
        public Ciudad Ciudad { get; set; } 
        public Pais Pais { get; set; }
        public Direccion Direccion {get; set;}
    }
}
