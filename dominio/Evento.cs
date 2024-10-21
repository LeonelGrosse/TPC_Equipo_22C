using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaEvento { get; set; }
        public Ciudad Ubicacion { get; set; }
        public decimal CostoInscripcion { get; set; }
        public char Estado { get; set; }
        public int RangoEdad { get; set; }
        public int CuposDisponibles { get; set; }
    }
}
