using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Disciplina
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public Decimal Distancia { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
