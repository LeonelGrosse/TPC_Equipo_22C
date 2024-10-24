using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public Usuario()
        {
            this.Rol = new Rol();
        }
        public int IdUsuario { get; set; }
        public Rol Rol { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasenia { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Imagen Imagen {get; set;}
        public bool Estado { get; set; } 
    }
}
