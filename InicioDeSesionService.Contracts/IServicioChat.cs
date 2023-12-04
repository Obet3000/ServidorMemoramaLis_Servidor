using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServidorMemoramaLis.Contracts
{
    [ServiceContract(CallbackContract = typeof(IServicioChatCallBack))]
    public interface IServicioChat
    {
        [OperationContract(IsOneWay = true)]
        void UnirseAChat(string nombreUsuario,string codigoDeChat);
        [OperationContract(IsOneWay = true)]
        void EnviarMensaje(string mensaje, string nombreUsuario, string codigoDeChat);
        [OperationContract(IsOneWay = true)]
        void SalirDelChat(string nombreDeUsuario, string codigoDeChat);
        [OperationContract(IsOneWay = true)]
        void CrearChat(string codigoDeChat);
        [OperationContract(IsOneWay = true)]
        void BorrarChat(string codigoDeChat);
    }
    public interface IServicioChatCallBack
    {
        [OperationContract(IsOneWay = true)]
        void RecibirMensaje(string nombreJugador, string mensaje);
    }
}
