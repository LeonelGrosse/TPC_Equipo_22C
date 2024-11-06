using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disciplina
    {
        public int IdDisciplina { get; set; }
        public string Descripcion { get; set; }
        public Decimal Distancia { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
