using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string NomUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string Contraseña { get; set; }
        public int IdPerfil { get; set; }
        public string NomPerfil { get; set; }
    }
}
