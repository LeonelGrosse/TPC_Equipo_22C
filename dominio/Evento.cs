﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Evento
    {
        public Evento()
        {
            Disciplina = new List<Disciplina>();
            Ubicacion = new Ubicacion();
            Imagen = new Imagen();
        }
        public enum DISCIPLINAS
        {
            Natacion = 1,
            Ciclismo = 2,
            Running = 3
        }
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public List<Disciplina> Disciplina { get; set; }
        public DateTime FechaEvento { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public decimal CostoInscripcion { get; set; }
        public char Estado { get; set; }
        public int EdadMinima { get; set; }
        public int EdadMaxima { get; set; }
        public int CuposDisponibles { get; set; }
        public Resultado Resultado { get; set; }
        public Imagen Imagen { get; set; }
    }
}
