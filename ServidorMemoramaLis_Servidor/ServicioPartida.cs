using Dominio;
using ServidorMemoramaLis.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServidorMemoramaLis_Servidor
{


    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class ServicioPartida : IServicioPartida
    {
        Dictionary<int, string> tableroGenerado = new Dictionary<int, string>
        {
            { 1, "1-Microsoft.png" },
            { 2, "2-VisualStudio.png" },
            { 3, "3-GitHub.png" },
            { 4, "4-Java.png" },
            { 5, "5-BUG.png" },
            { 6, "6-Laptop.png" },
            { 7, "7-CPlusPlus.png" },
            { 8, "8.StackOverFlow.png" },
            { 9, "9-Angular.png" },
            { 10, "10-JavaScript.png" },
            { 11, "11-Scrum.png" },
            { 12, "12-GoogleCloud.png" },
            { 13, "13-AmazonWebService.png" },
            { 14, "14-AndroidStudio.png" },
            { 15, "15-CicloDeVida.png" },
            { 16, "16-DiagramaDeComunicacion.png" },
            { 17, "17-UML.png" },
            { 18, "18-DiagramaDeEstados.png" },
            { 19, "19-DiagramaDeSecuencia.png" },
            { 20, "20-EnterpriseArchitect.png" },
            { 21, "21-Atom.png" },
            { 22, "22-DiagramaDeClases.png" },
            { 23, "23-FishBone.png" },
            { 24, "24-SixSigma.png" },
            { 25, "25-MySql.png" },
            { 26, "26-SqlServer.png" },
            { 27, "27-Figma.png" },
            { 28, "28-Diseño.png" },
            { 29, "29-Testing.png" },
            { 30, "30-Requerimientos.png" },
            { 31, "31-Desarrollo.png" },
            { 32, "32-Codigo.png" },
            { 33, "33-Python.png" },
            { 34, "34-Lisp.png" },
            { 35, "35-Prolog.png" },
            { 36, "36-Git.png" },
            { 37, "37-Linux.png" },
            { 38, "38-Window.png" },
            { 39, "39-TcpIp.png" },
            { 40, "40-AdaLovace.png" },
            { 41, "41-Oracle.png" },
            { 42, "42-BaseDeDatos.png" },
            { 43, "43-Azure.png" },
            { 44, "44-Bash.png" },
            { 45, "45-Docker.png" },
            { 46, "46-C.png" },
            { 47, "47-Php.png" },
            { 48, "48-DennisRitchie.png" },
            { 49, "49-BrianKernigan.png" },
            { 50, "50-AlanTuring.png" },
            { 51, "1-Microsoft.png" },
            { 52, "2-VisualStudio.png" },
            { 53, "3-GitHub.png" },
            { 54, "4-Java.png" },
            { 55, "5-BUG.png" },
            { 56, "6-Laptop.png" },
            { 57, "7-CPlusPlus.png" },
            { 58, "8-StackOverFlow.png" },
            { 59, "9-Angular.png" },
            { 60, "10-JavaScript.png" },
            { 61, "11-Scrum.png" },
            { 62, "12-GoogleCloud.png" },
            { 63, "13-AmazonWebService.png" },
            { 64, "14-AndroidStudio.png" },
            { 65, "15-CicloDeVida.png" },
            { 66, "16-DiagramaDeComunicacion.png" },
            { 67, "17-UML.png" },
            { 68, "18-DiagramaDeEstados.png" },
            { 69, "19-DiagramaDeSecuencia.png" },
            { 70, "20-EnterpriseArchitect.png" },
            { 71, "21-Atom.png" },
            { 72, "22-DiagramaDeClases.png" },
            { 73, "23-FishBone.png" },
            { 74, "24-SixSigma.png" },
            { 75, "25-MySql.png" },
            { 76, "26-SqlServer.png" },
            { 77, "27-Figma.png" },
            { 78, "28-Diseño.png" },
            { 79, "29-Testing.png" },
            { 80, "30-Requerimientos.png" },
            { 81, "31-Desarrollo.png" },
            { 82, "32-Codigo.png" },
            { 83, "33-Python.png" },
            { 84, "34-Lisp.png" },
            { 85, "35-Prolog.png" },
            { 86, "36-Git.png" },
            { 87, "37-Linux.png" },
            { 88, "38-Window.png" },
            { 89, "39-TcpIp.png" },
            { 90, "40-AdaLovace.png" },
            { 91, "41-Oracle.png" },
            { 92, "42-BaseDeDatos.png" },
            { 93, "43-Azure.png" },
            { 94, "44-Bash.png" },
            { 95, "45-Docker.png" },
            { 96, "46-C.png" },
            { 97, "47-Php.png" },
            { 98, "48-DennisRitchie.png" },
            { 99, "49-BrianKernigan.png" },
            { 100, "50-AlanTuring.png" },
        };

        List<PartidasDTO> partidasActivas = new List<PartidasDTO>();

        public void ActualizarInformacionDeJugador(JugadoresDTO jugador, string codigoDePartida)
        {
            partidasActivas.FirstOrDefault(partidaBuscada => partidaBuscada.CodigoPartida == codigoDePartida).Jugadores.FirstOrDefault(j => j.NombreJugador == jugador.NombreJugador).Conexion = OperationContext.Current;
            PartidasDTO partida = new PartidasDTO();
            partida = partidasActivas.FirstOrDefault(partidaBuscada => partidaBuscada.CodigoPartida == codigoDePartida);
            partida.Jugadores.ElementAt(0).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().RecibirTurno(0);
            for (int i = 0; i < partida.Jugadores.Count(); i++)
            {
                partida.Jugadores.ElementAt(i).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().ObtenerListaDeJugadores(partida.Jugadores);
            }

        }

        public void BorrarPartida(string codigoDePartida)
        {
            var partidaEliminar= partidasActivas.FirstOrDefault(partida => partida.CodigoPartida == codigoDePartida);
            if (partidaEliminar != null)
            {
                partidasActivas.Remove(partidaEliminar);
            }
        }

        public void ContarJugadores(string codigoDePartida)
        {
            throw new NotImplementedException();
        }

        public void CrearPartida(string codigoDePartida)
        {

            PartidasDTO partidaDTO = new PartidasDTO();
            var random = new Random();
            var tableroRevuelto = tableroGenerado.OrderBy(x => random.Next()).ToDictionary(item => item.Key, item => item.Value);
            partidaDTO.NumeroJugadores = 0;
            partidaDTO.Tablero = tableroRevuelto;
            partidaDTO.Jugadores = new List<JugadoresDTO>();
            partidaDTO.IdPartida = codigoDePartida;
            partidaDTO.CodigoPartida = codigoDePartida;
            partidasActivas.Add(partidaDTO);
           
        }

        public void EnviarMovimiento(int movimiento, string nombreUsuario, string codigoDePartida, string resultado, string tipo)
        {
            PartidasDTO partida = new PartidasDTO();
            partida = partidasActivas.FirstOrDefault(partidaBuscada => partidaBuscada.CodigoPartida == codigoDePartida);
            if (partida != null)
            {
                for (int i = 0; i < partida.Jugadores.Count(); i++)
                {
                    try
                    {
                        partida.Jugadores.ElementAt(i).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().RecibirMovimiento(nombreUsuario, movimiento, resultado);   
                        if (resultado.Equals("Asertado"))
                        {
                            partidasActivas.FirstOrDefault(partidaBuscada => partidaBuscada.CodigoPartida == codigoDePartida).Jugadores.FirstOrDefault(jugador => jugador.NombreJugador == nombreUsuario).puntos += 1;
                        }
                    }
                    catch (CommunicationObjectAbortedException)
                    {
                        partida.Jugadores.ElementAt(i).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().ExpulsarJugador(partida.Jugadores.ElementAt(i).NombreJugador);
                        partida.Jugadores.Remove(partida.Jugadores.ElementAt(i));
                    }
                }
            }
        }


        public void IniciarJuego(string codigoDePartida)
        {
            PartidasDTO partidaAIniciar = new PartidasDTO();
            partidaAIniciar = partidasActivas.FirstOrDefault(partida => partida.CodigoPartida == codigoDePartida);
            
            if (partidaAIniciar != null) {
                for (int i = 0; i < partidaAIniciar.Jugadores.Count(); i++)
                {
                    try
                    {
                        partidaAIniciar.Jugadores.ElementAt(i).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().RecibirTablero(partidaAIniciar.Tablero);
                        partidaAIniciar.Jugadores.ElementAt(i).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().RecibirEstadoDePartida("Iniciando");
                        
                    }
                    catch (CommunicationObjectAbortedException)
                    {
                        partidaAIniciar.Jugadores.ElementAt(i).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().ExpulsarJugador(partidaAIniciar.Jugadores.ElementAt(i).NombreJugador);
                        partidaAIniciar.Jugadores.Remove(partidaAIniciar.Jugadores.ElementAt(i));
                    }
                }
            }
        }

        public void PasarTurno(int turno,string codigoDePartida)
        {
            PartidasDTO partida = new PartidasDTO();
            partida = partidasActivas.FirstOrDefault(partidaBuscada => partidaBuscada.CodigoPartida == codigoDePartida);
            if (partida != null)
            {
                   try
                   {
                    partida.Jugadores.ElementAt(turno).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().RecibirTurno(turno);
                   }
                    catch (CommunicationObjectAbortedException)
                    {
                    partida.Jugadores.ElementAt(turno).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().ExpulsarJugador(partida.Jugadores.ElementAt(turno).NombreJugador);
                    partida.Jugadores.Remove(partida.Jugadores.ElementAt(turno));
                    }
                
            }
        }

        public void ReportarJugador(string nombreDeUSuario, string codigoDePartida)
        {
            throw new NotImplementedException();
        }

        public void SalirDePartida(string nombreDeUsuario, string codigoDePartida)
        {
            PartidasDTO partida = new PartidasDTO();
            partida = partidasActivas.FirstOrDefault(partidaBuscada => partidaBuscada.CodigoPartida == codigoDePartida);
            JugadoresDTO jugadorRetirado = partida.Jugadores.FirstOrDefault(j => j.NombreJugador == nombreDeUsuario);
            if (partida != null)
            {
                try
                {
                    partida.Jugadores.Remove(jugadorRetirado);
                    if (partida.Jugadores.Count() == 0)
                    {
                        partidasActivas.Remove(partida);        
                    }

                }
                catch (CommunicationObjectAbortedException)
                {
                    
                }

            }
        }

        public void TerminarPartida(string codigoDePartida)
        {
           
        }

        public void UnirseAPartida(JugadoresDTO jugador, string codigoDePartida)
        { 
                var partidaEncontrada = partidasActivas.FirstOrDefault(partida => partida.CodigoPartida == codigoDePartida);
            if (partidaEncontrada != null)
            {
                if (partidaEncontrada.Jugadores.Count() < 4)
                {
                    jugador.Conexion = OperationContext.Current;

                    partidaEncontrada.Jugadores.Add(jugador);
                    jugador.Conexion.GetCallbackChannel<IServicioPartidaCallBack>().RespuestaDeUnirseAPartida("200");

                    Task tarea = new Task(() =>
                    {
                        for (int i = 0; i < partidaEncontrada.Jugadores.Count(); i++)
                        {
                            try
                            {
                                partidaEncontrada.Jugadores.ElementAt(i).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().ObtenerListaDeJugadores(partidaEncontrada.Jugadores);


                            }
                            catch (CommunicationObjectAbortedException)
                            {
                                partidaEncontrada.Jugadores.ElementAt(i).Conexion.GetCallbackChannel<IServicioPartidaCallBack>().ExpulsarJugador(partidaEncontrada.Jugadores.ElementAt(i).NombreJugador);
                                partidaEncontrada.Jugadores.Remove(partidaEncontrada.Jugadores.ElementAt(i));
                            }
                        }
                    });
                    tarea.Start();
                }
                else
                {
                    jugador.Conexion = OperationContext.Current;
                    jugador.Conexion.GetCallbackChannel<IServicioPartidaCallBack>().RespuestaDeUnirseAPartida("409");
                }
            }
            else
            {
                jugador.Conexion = OperationContext.Current;
                jugador.Conexion.GetCallbackChannel<IServicioPartidaCallBack>().RespuestaDeUnirseAPartida("500");
            }
            
           
        }
    }
}
