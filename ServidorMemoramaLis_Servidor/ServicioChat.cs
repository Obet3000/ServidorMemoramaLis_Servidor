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
    public class ServicioChat : IServicioChat
    {
        List<PartidasDTO> chatsActivos = new List<PartidasDTO>();
        public void BorrarChat(string codigoDeChat)
        {
            var chat = chatsActivos.FirstOrDefault(chatPartida => chatPartida.codigoPartida == codigoDeChat);
            if (chat != null)
            {
                chatsActivos.Remove(chat);
            }
        }

        public void CrearChat(string codigoDeChat)
        {
            List<Partidas_JugadoresDTO> partidas_JugadoresDTO = new List<Partidas_JugadoresDTO>();

            PartidasDTO partidaDTO = new PartidasDTO()
            {
                codigoPartida = codigoDeChat,
                Partidas_Jugadores = partidas_JugadoresDTO
            };
            chatsActivos.Add(partidaDTO);
        }

        public void EnviarMensaje(string mensaje, string nombreUsuario, string codigoDeChat)
        {
            var chat = chatsActivos.FirstOrDefault(chatPartida => chatPartida.codigoPartida == codigoDeChat);
            if (chat != null)
            {
                Task tarea = new Task(() => {

                    for (int i = 0; i < chat.Partidas_Jugadores.Count(); i++)
                    {
                        try
                        {
                            chat.Partidas_Jugadores.ElementAt(i).Jugadores.Conexion.GetCallbackChannel<IServicioChatCallBack>().RecibirMensaje(nombreUsuario, mensaje);
                        }
                        catch (CommunicationObjectAbortedException)
                        {
                            chat.Partidas_Jugadores.Remove(chat.Partidas_Jugadores.ElementAt(i));
                        }
                    }
                });
                tarea.Start();
            }
        }

        public void SalirDelChat(string nombreDeUsuario, string codigoDeChat)
        {
            var chat = chatsActivos.FirstOrDefault(chatPartida => chatPartida.codigoPartida == codigoDeChat);
            if (chat != null)
            {
                var jugadorEncontrado = chat.Partidas_Jugadores.FirstOrDefault(jugador => jugador.Jugadores.NombreJugador == nombreDeUsuario);
                if (jugadorEncontrado != null)
                {
                    jugadorEncontrado.Jugadores.Conexion.GetCallbackChannel<IServicioChatCallBack>().RecibirMensaje(jugadorEncontrado.Jugadores.NombreJugador, "PNKUFze2Vj1TcSymht+N0g==");
                    chat.Partidas_Jugadores.Remove(jugadorEncontrado);
                    EnviarMensaje("Adios a todos", nombreDeUsuario, codigoDeChat);
                }
            }
        }

        public void UnirseAChat(string nombreUsuario, string codigoDeChat)
        {
            var chat = chatsActivos.FirstOrDefault(chatPartida => chatPartida.codigoPartida == codigoDeChat);
            if (chat != null)
            {
                JugadoresDTO jugadores = new JugadoresDTO()
                {
                    NombreJugador = nombreUsuario,
                };
                jugadores.Conexion = OperationContext.Current;
                Partidas_JugadoresDTO partidaJugadores = new Partidas_JugadoresDTO();
                partidaJugadores.Jugadores = jugadores;
                partidaJugadores.Jugadores.NombreJugador = nombreUsuario;
                PartidasDTO informacionPartida = new PartidasDTO();
                partidaJugadores.Partidas=informacionPartida;
                partidaJugadores.Partidas.codigoPartida = codigoDeChat;
                chat.Partidas_Jugadores.Add(partidaJugadores);
                EnviarMensaje("Entre al chat ", nombreUsuario, codigoDeChat);

            }
        }
    }
}

