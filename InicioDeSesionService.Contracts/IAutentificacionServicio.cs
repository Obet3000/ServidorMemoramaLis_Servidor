using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServidorMemoramaLis.Contracts
{
    [ServiceContract(CallbackContract = typeof(IAutentificacionServicioCallBack))]
    public interface IAutentificacionServicio
    {
        [OperationContract(IsOneWay = true)]
        void AutentificacionUsuario(String email, String contrasenia);
 }
    public interface IAutentificacionServicioCallBack
    {
        [OperationContract(IsOneWay = true)]
        void RespuestaAutentificacion(JugadoresDTO jugador);

    }
}
