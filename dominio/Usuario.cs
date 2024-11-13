using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum Roles
    {
        Administrador = 1,
        Participante = 2,
        Organizador = 3
    }
    public class Usuario
    {
        public Usuario()
        {
            this.Rol = new Rol();
            this.Imagen = new Imagen();
        }

        public bool EsAdministrador()
        {
            if (this.Rol.IdRol == (int)Roles.Administrador)
                return true;
            return false;
        }
        public bool EsParticipante()
        {
            if (this.Rol.IdRol == (int)Roles.Participante)
                return true;
            return false;
        }
        public bool EsOrganizador()
        {
            if (this.Rol.IdRol == (int)Roles.Organizador)
                return true;
            return false;
        }
        public int IdUsuario { get; set; }
        public Rol Rol { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasenia { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Imagen Imagen { get; set; }
        public bool Estado { get; set; }
    }
}
