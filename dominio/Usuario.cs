using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public string correoElectronico { get; set; }
        public string contrasenia { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public Ciudad idCiudad { get; set; }
        public bool estado { get; set; }
    }
}
