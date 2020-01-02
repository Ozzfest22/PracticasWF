using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Jugador
    {
        public int IdJugador { get; set; }
        public string DniJugador { get; set; }
        public string NomJugador { get; set; }
        public string ApePatJugador { get; set; }
        public string ApeMatJugador { get; set; }
        public string Apellidos { get; set; }
        public int EdadJugador { get; set; }
        public int IdEquipo { get; set; }
        public string NomEquipo { get; set; } 
    }
}
