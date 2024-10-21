using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Resultado
    {
        public string DNI { get; set; }
        public string Email { get; set; }
        public List<TiempoPorDisciplina> Tiempo { get; set; }
    }
}
