using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class TiempoPorDisciplina
    {
        public int IDDisciplina{ get; set; } // string o Disciplina?
        public TimeSpan Tiempo { get; set; }
    }
}
