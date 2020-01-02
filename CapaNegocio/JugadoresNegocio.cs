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
    public class JugadoresNegocio
    {

        JugadoresDatos jd = new JugadoresDatos();

        public bool ActualizarJugador(Jugador jug)
        {
            return jd.ActualizarJugador(jug);
        }

        public Jugador ConsultarJugador(int codigo)
        {
            return jd.ConsultarJugador(codigo);
        }

        public DataTable LlenarCombo(string op)
        {
            return jd.LlenarCombo(op);
        }

        public bool InsertarJugador(Jugador jug)
        {
            return jd.InsertarJugador(jug);
        }

        public DataTable ListarJugadores_BC()
        {
            return jd.ListarJugadores_BC();
        }

        public DataTable ListarJugadores_RM()
        {
            return jd.ListarJugadores_RM();
        }

        public DataTable BusquedaJugador_BC(string valor)
        {
            return jd.BusquedaJugador_BC(valor);
        }

        public DataTable BusquedaJugador_RM(string valor)
        {
            return jd.BusquedaJugador_RM(valor);
        }
    }
}
