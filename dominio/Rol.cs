using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Rol
    {
        public int idRol { get; set; }
        public string rol { get; set; }
        public override string ToString()
        {
            return rol;
        }
    }
}
