using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [DataContract]
    public class JugadoresDTO
    {
            [DataMember]
            public string idJugador { get; set; }

            [DataMember]
            public string nombreJugador { get; set; }

            [DataMember]
            public string contrasenia { get; set; }

            [DataMember]
            public string email { get; set; }

            [DataMember]
            public string Fotos { get; set; }
            [DataMember]
            public bool EstadoConexion;
    }
    }

