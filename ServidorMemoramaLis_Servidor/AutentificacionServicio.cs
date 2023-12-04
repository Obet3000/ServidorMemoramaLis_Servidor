using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using ServidorMemoramaLis.Contracts;
using System.Threading;
using AccesoADatos;
using System.Data.Entity.Core;
using System.Transactions;

namespace ServidorMemoramaLis_Servidor
{
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AutentificacionServicio : IAutentificacionServicio
    {
        Dictionary<string, OperationContext> jugadoresActivos = new Dictionary<string, OperationContext>();
        public void AutentificacionUsuario(string usuario, string contrasenia)
        {
            JugadoresDTO jugadorDTO = RespuestaAutenficacionJugador(usuario, contrasenia);

            if (jugadorDTO.NombreJugador != null && !jugadoresActivos.ContainsKey(jugadorDTO.NombreJugador))
            {
                jugadoresActivos.Add(jugadorDTO.NombreJugador, OperationContext.Current);
            }
            OperationContext.Current.GetCallbackChannel<IAutentificacionServicioCallBack>().RespuestaAutentificacion(jugadorDTO);
            
        }

        public JugadoresDTO RespuestaAutenficacionJugador(string email, string contrasenia)
        {
            JugadoresDTO jugadorDTO = new JugadoresDTO()
            {
                EstadoConexion = false
            };

            using (var context = new MemoramaLISEntities())
            {
                Jugadores jugador = context.Jugadores.FirstOrDefault(j => j.email == email);
                bool login = context.Logins.Any(l => l.idJugador == jugador.idJugador && l.contrasenia == contrasenia);
                if (login)
                {
                    jugadorDTO.EstadoConexion = true;
                    jugadorDTO.Email = jugador.email;
                    jugadorDTO.NombreJugador = jugador.nombreJugador;
                    jugadorDTO.Fotos = jugador.Fotos;
                }
                return jugadorDTO;
            }
        }
    }
    


}
