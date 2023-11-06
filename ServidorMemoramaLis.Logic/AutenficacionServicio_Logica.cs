using AccesoADatos;
using Dominio;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Transactions;
using Microsoft.Build.Utilities;

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

            using (var context = new MemoramaLISEntities())
            {
                Jugadores jugador = context.Jugadores.FirstOrDefault(j => j.email == nombreJugador && j.contrasenia == contrasenia);

                if (jugador != null)
                {
                    jugadorDTO.EstadoConexion = true;
                    jugadorDTO.Email = jugador.email;
                    jugadorDTO.NombreJugador = jugador.nombreJugador;
                    jugadorDTO.Fotos = jugador.Fotos;
                }
                return jugadorDTO;
            }
        }

        public bool RegistrarJugador(JugadoresDTO jugadorDTO)
        {
            bool status = false;
            using (var context = new MemoramaLISEntities())
            {
                Jugadores nuevoJugador = new Jugadores
                {
                    idJugador = Guid.NewGuid(),
                    nombreJugador = jugadorDTO.NombreJugador,
                    contrasenia = jugadorDTO.Contrasenia,
                    email = jugadorDTO.Email,
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


