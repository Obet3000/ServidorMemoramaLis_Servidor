using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using ServidorMemoramaLis.Logic;
using ServidorMemoramaLis.Contracts;
using System.Threading;

namespace ServidorMemoramaLis_Servidor
{
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class AutentificacionServicio : IAutentificacionServicio
    {
        Dictionary<string, OperationContext> jugadoresActivos = new Dictionary<string, OperationContext>();
        public void AutentificacionUsuario(string usuario, string contrasenia)
        {
            AutenficacionServicio_Logica autenficacionServicio_Logica = new AutenficacionServicio_Logica();
            JugadoresDTO jugadorDTO = autenficacionServicio_Logica.respuestaAutenficacionJugador(usuario, contrasenia);

            if (jugadorDTO.NombreJugador != null && !jugadoresActivos.ContainsKey(jugadorDTO.NombreJugador))
            {
                jugadoresActivos.Add(jugadorDTO.NombreJugador, OperationContext.Current);
            }
            OperationContext.Current.GetCallbackChannel<IAutentificacionServicioCallBack>().RespuestaAutentificacion(jugadorDTO);
            
        }

        public void RegistroJugador(JugadoresDTO jugador)
        {
            AutenficacionServicio_Logica autenficacionServicio_Logica = new AutenficacionServicio_Logica();
            bool status = autenficacionServicio_Logica.RegistrarJugador(jugador);
            OperationContext.Current.GetCallbackChannel<IAutentificacionServicioCallBack>().Respuestaregistro(status);


        }

        public void UsuarioExistente(string usuario, string correo)
        {
            throw new NotImplementedException();
        }

        public void ValidacionDeEmail(string correo)
        {
            throw new NotImplementedException();
        }
    }



}
