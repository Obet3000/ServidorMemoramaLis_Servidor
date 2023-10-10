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
        void AutentificacionUsuario(String usuario, String contrasenia);

        [OperationContract(IsOneWay = true)]
        void RegistroJugador(JugadoresDTO jugador);

        [OperationContract(IsOneWay = true)]
        void ValidacionDeEmail(String correo);

        [OperationContract(IsOneWay = true)]
        void UsuarioExistente(string usuario, string correo);
    }
    public interface IAutentificacionServicioCallBack
    {
        [OperationContract(IsOneWay = true)]
        void RespuestaAutentificacion(JugadoresDTO jugador);

        [OperationContract(IsOneWay = true)]
        void RespuestaEmail(string codigoVerificacíon);

        [OperationContract(IsOneWay = true)]
        void Respuestaregistro(bool estado);
        [OperationContract(IsOneWay = true)]
        void RespuestaUsuarioExistente(bool status);
    }
}
