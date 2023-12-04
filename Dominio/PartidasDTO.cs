using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [DataContract]
    public class PartidasDTO
    {
        [DataMember]
        public string IdPartida { get; set; }
        [DataMember]
        public int NumeroJugadores { get; set; }
        [DataMember]
        public int EstadoPartida { get; set; }
        [DataMember]
        public string CodigoPartida { get; set; }
        [DataMember]
        public List<JugadoresDTO> Jugadores { get; set; }
        [DataMember]
        public Dictionary<int, string> Tablero { get; set; }
    }
}
