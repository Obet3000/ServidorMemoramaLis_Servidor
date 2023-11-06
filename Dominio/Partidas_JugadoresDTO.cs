using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Partidas_JugadoresDTO
    {
        public string idPartida_IdJugador { get; set; }
        public string idPartida { get; set; }
        public System.Guid idJugador { get; set; }
        public virtual JugadoresDTO Jugadores { get; set; }
        public virtual PartidasDTO Partidas { get; set; }
    }
}
