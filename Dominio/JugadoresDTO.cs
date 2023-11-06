using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [DataContract]
    public class JugadoresDTO
    {
            [DataMember]
            public string IdJugador { get; set; }

            [DataMember]
            public string NombreJugador { get; set; }

            [DataMember]
            public string Contrasenia { get; set; }

            [DataMember]
            public string Email { get; set; }

            [DataMember]
            public string Fotos { get; set; }
            [DataMember]
            public bool EstadoConexion;

            public OperationContext Conexion { get; set; }
    }
    }

