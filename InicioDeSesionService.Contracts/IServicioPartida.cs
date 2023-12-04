using Dominio;
using ServidorMemoramaLis.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServidorMemoramaLis.Contracts

{
    [ServiceContract(CallbackContract = typeof(IServicioPartidaCallBack))]

    public interface IServicioPartida
    {
        [OperationContract(IsOneWay = true)]
        void UnirseAPartida(JugadoresDTO jugador, string codigoDePartida);
        [OperationContract(IsOneWay = true)]
        void EnviarMovimiento(int movimiento, string nombreUsuario, string codigoDePartida, string resultado, string tipo);
        [OperationContract(IsOneWay = true)]
        void SalirDePartida(string nombreDeUsuario, string codigoDePartida);
        [OperationContract(IsOneWay = true)]
        void CrearPartida(string codigoDePartida);
        [OperationContract(IsOneWay = true)]
        void BorrarPartida(string codigoDePartida);
        [OperationContract(IsOneWay = true)]
        void ContarJugadores(string codigoDePartida);
        [OperationContract(IsOneWay = true)]
        void IniciarJuego(string codigoDePartida);
        [OperationContract(IsOneWay = true)]
        void ActualizarInformacionDeJugador(JugadoresDTO jugador, string codigoDePartida);
        [OperationContract(IsOneWay = true)]
        void ReportarJugador(string nombreDeUSuario, string codigoDePartida);
        [OperationContract(IsOneWay = true)]
        void TerminarPartida(string codigoDePartida);
        [OperationContract(IsOneWay = true)]
        void PasarTurno(int turno, string codigoDePartida);
    }
    public interface IServicioPartidaCallBack
    {
        [OperationContract(IsOneWay = true)]
        void RecibirTablero(Dictionary<int, string> tablero);
        [OperationContract(IsOneWay = true)]
        void RecibirMovimiento(string nombreJugador, int movimiento, string resultado);
        [OperationContract(IsOneWay = true)]
        void ExpulsarJugador(string nombreJugador);
        [OperationContract(IsOneWay = true)]
        void ObtenerListaDeJugadores(List<JugadoresDTO> jugadores);
        [OperationContract(IsOneWay = true)]
        void ObtenerJugadorReportado(bool estado);
        [OperationContract(IsOneWay = true)]
        void RespuestaDeUnirseAPartida(string codigoDeRespuesta);
        [OperationContract(IsOneWay = true)]
        void MostrarTerminarPartida(List<string> ganadores, int puntos);
        [OperationContract(IsOneWay = true)]
        void RecibirEstadoDePartida(string codigoDeRespuesta);
        [OperationContract(IsOneWay = true)]
        void RecibirTurno(int turno);
    }
}
