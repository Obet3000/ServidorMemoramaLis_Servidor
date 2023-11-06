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
        public string idPartida { get; set; }
        [DataMember]
        public int numeroJugadores { get; set; }
        [DataMember]
        public string codigoPartida { get; set; }
        [DataMember]
        public virtual ICollection<Partidas_JugadoresDTO> Partidas_Jugadores { get; set; }


    }
}
