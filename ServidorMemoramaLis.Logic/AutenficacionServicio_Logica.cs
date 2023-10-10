using AccesoABaseDeDatos;
using Dominio;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Transactions;
using Microsoft.Build.Utilities;
using Serilog;

namespace ServidorMemoramaLis.Logic
{
    public class AutenficacionServicio_Logica
    {
        public JugadoresDTO respuestaAutenficacionJugador(string nombreJugador, string contrasenia)
        {
            JugadoresDTO jugadorDTO = new JugadoresDTO()
            {
                EstadoConexion = false
            };
            using (var context = new AccesoABaseDeDatos.MemoramaLis())
            {
                var jugador = context.Jugadores.FirstOrDefault(j => j.nombreJugador == nombreJugador && j.contrasenia == contrasenia);

                jugadorDTO.nombreJugador = jugador.nombreJugador;
                jugadorDTO.email = jugador.email;
                jugadorDTO.EstadoConexion = true;
            }
            return jugadorDTO;
        }
        public bool RegistrarJugador(JugadoresDTO jugadorDTO)
        {
            bool status = false;
            using (var context = new MemoramaLis())
            {
                var nuevoJugador = new Jugadores
                {
                    idJugador = Guid.NewGuid().ToString(), 
                    nombreJugador = jugadorDTO.nombreJugador,
                    contrasenia = jugadorDTO.contrasenia,
                    email = jugadorDTO.email,
                    Fotos = jugadorDTO.Fotos,
                };

                context.Jugadores.Add(nuevoJugador);

                try
                {
                    var resultado = context.SaveChanges();
                    if (resultado > 0)
                    {
                        status = true;
                    }
                }
                catch (EntityException ex)
                {
                    Transaction.Current.Rollback();
                }
                return status;
            }
        }
    }
}


