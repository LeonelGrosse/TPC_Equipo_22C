using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace accesorio
{
    public static class Seguridad
    {
        public static Usuario UsuarioLogueado;
        public static bool SesionActiva(object usuario)
        {
            UsuarioLogueado = usuario != null ? (Usuario)usuario : null;

            if (UsuarioLogueado != null && UsuarioLogueado.Rol.IdRol != 0)
                return true;

            return false;
        }
        public static bool RestringirAcceso(object usuario, Roles rol)
        {
            UsuarioLogueado = (usuario != null ? (Usuario)usuario : null);

            if (UsuarioLogueado != null && UsuarioLogueado.Rol.IdRol != (int)rol)
                return true;

            return false;
        }
    }
}
