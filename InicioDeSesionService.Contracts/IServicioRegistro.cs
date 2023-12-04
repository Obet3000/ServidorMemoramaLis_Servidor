using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServidorMemoramaLis.Contracts
{
    [ServiceContract(CallbackContract = typeof(IServicioRegistroCallBack))]

    public interface IServicioRegistro
    {
        [OperationContract(IsOneWay = true)]
        void EnviarCodigoDeValidacion(string email, string destinatario);
        [OperationContract(IsOneWay = true)]
        void ValidarCodigo(JugadoresDTO jugadorDTO, int codigo);
        [OperationContract(IsOneWay = true)]
        void UsuarioExistente(string usuario, string email);
    }

    public interface IServicioRegistroCallBack
    {
        void RecibirRespuesta(string codigo);

    }
}
