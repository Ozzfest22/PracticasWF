using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaNegocio
{
    public class UsuariosNegocio
    {
        UsuarioDatos ud = new UsuarioDatos();

        public DataTable IngresoUsuario(Usuarios usu)
        {
            return ud.IngresoUsuario(usu);
        }
    }
}
