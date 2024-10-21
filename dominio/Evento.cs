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
        public int idEvento { get; set; }
        public string nombre { get; set; }
        public DateTime fechaEvento { get; set; }
        public Ciudad ubicacion { get; set; }
        public SqlMoney costoInscripcion { get; set; }
        public char estado { get; set; }
        public int rangoEdad { get; set; }
        public int cuposDisponibles { get; set; }
    }
}
