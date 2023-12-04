using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServidorMemoramaLis.Contracts;
using Dominio;
using System.ServiceModel;
using System.Net.Mail;
using System.Net;
using AccesoADatos;
using System.Data.Entity.Core;
using System.Transactions;

namespace ServidorMemoramaLis_Servidor
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class ServicioRegistro : IServicioRegistro
    {
        Dictionary<string, CodigoConVencimiento> CodigoActivos = new Dictionary<string, CodigoConVencimiento>();
        public void EnviarCodigoDeValidacion(string email, string destinatario)
        {
            Task tarea = new Task(() =>
            {
                var MemoramaLisEmail = "CorreoMemoramaLis@outlook.com";
                var contrasenia = "N_48M4J.zTP59:k";

                var client = new SmtpClient("smtp-mail.outlook.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(MemoramaLisEmail, contrasenia)
                };
                Random random = new Random();
                int codigoDeValidacion = random.Next(100000, 999999);

                var mensaje = new MailMessage(MemoramaLisEmail, destinatario)
                {
                    Subject = "Código de validación MemoramaLIS",
                    Body = $"Hola, tu código de validación es {codigoDeValidacion}. /n No lo compartas con nadie más."
                };

                var codigoConVencimiento = new CodigoConVencimiento(codigoDeValidacion, DateTime.Now.AddMinutes(3));
                CodigoActivos.Add(email, codigoConVencimiento);

                try
                {
                    client.Send(mensaje);
                }
                catch (SmtpException)
                {
                    OperationContext.Current.GetCallbackChannel<IServicioRegistroCallBack>().RecibirRespuesta($"No hemos logrado enviar el código.");
                }
                catch (Exception)
                {
                    OperationContext.Current.GetCallbackChannel<IServicioRegistroCallBack>().RecibirRespuesta($"Ocurrió un error inesperado");
                }
            });

            tarea.Start();
        }

        public void ValidarCodigo(JugadoresDTO jugadorDTO, int codigo)
        {
            if (CodigoActivos.TryGetValue(jugadorDTO.Email, out CodigoConVencimiento codigoConVencimiento))
            {
                if (codigoConVencimiento.Codigo == codigo && DateTime.Now <= codigoConVencimiento.TiempoVencimiento)
                {
                    RegistrarJugador(jugadorDTO);
                    OperationContext.Current.GetCallbackChannel<IServicioRegistroCallBack>().RecibirRespuesta($"El código de validación es correcto.");
                }
                else if (DateTime.Now > codigoConVencimiento.TiempoVencimiento)
                {
                    OperationContext.Current.GetCallbackChannel<IServicioRegistroCallBack>().RecibirRespuesta($"El código de validación ha expirado.");
                    CodigoActivos.Remove(jugadorDTO.Email); 
                }
                else
                {
                    OperationContext.Current.GetCallbackChannel<IServicioRegistroCallBack>().RecibirRespuesta($"El código de validación es incorrecto.");
                }
            }
            else
            {
                OperationContext.Current.GetCallbackChannel<IServicioRegistroCallBack>().RecibirRespuesta($"No se encontró el código de validación para el correo electrónico proporcionado.");
            }
        }

        


        public bool RegistrarJugador(JugadoresDTO jugadorDTO)
        {
            bool status = false;
            ServicioRegistro servicioValidacion = new ServicioRegistro();
            using (var context = new MemoramaLISEntities())
            {
                bool jugadorExistente = context.Jugadores.Any(j => j.nombreJugador == jugadorDTO.NombreJugador || j.email == jugadorDTO.Email);
                if (!jugadorExistente)
                {
                    Jugadores nuevoJugador = new Jugadores
                    {
                        idJugador = Guid.NewGuid(),
                        nombreJugador = jugadorDTO.NombreJugador,
                        contrasenia = jugadorDTO.Contrasenia,
                        email = jugadorDTO.Email,
                        Fotos = jugadorDTO.Fotos,
                    };

                    Logins loginJugadorNuevo = new Logins
                    {
                        idLogin = Guid.NewGuid(),
                        contrasenia = jugadorDTO.Contrasenia,
                        email = jugadorDTO.Email,
                        idJugador = nuevoJugador.idJugador
                    };

                    context.Jugadores.Add(nuevoJugador);
                    context.Logins.Add(loginJugadorNuevo);
                    try
                    {
                        var resultado = context.SaveChanges();
                        if (resultado > 0)
                        {
                            status = true;
                        }
                    }
                    catch (EntityException)
                    {
                        Transaction.Current.Rollback();
                    }
                }
                return status;
            }
        }

        public void UsuarioExistente(string usuario, string email)
        {
            try
            {
                using (var context = new MemoramaLISEntities())
                {
                    bool jugadorYaRegistrado = context.Jugadores.Any(j => j.nombreJugador == usuario || j.email == email);
                    if (jugadorYaRegistrado)
                    {
                        OperationContext.Current.GetCallbackChannel<IServicioRegistroCallBack>().RecibirRespuesta("Usuario ya existente");
                    }
                    else
                    {
                        OperationContext.Current.GetCallbackChannel<IServicioRegistroCallBack>().RecibirRespuesta("Usuario disponible");
                    }
                }
            }
            catch (EntityException)
            {
                OperationContext.Current.GetCallbackChannel<IServicioRegistroCallBack>().RecibirRespuesta("Error al verificar el usuario");
            }
            catch (Exception)
            {
                OperationContext.Current.GetCallbackChannel<IServicioRegistroCallBack>().RecibirRespuesta("Ha ocurrido un error, intentelo más tarde");
            }
        }



        public class CodigoConVencimiento
        {
            public int Codigo { get; }
            public DateTime TiempoVencimiento { get; }

            public CodigoConVencimiento(int codigo, DateTime tiempoVencimiento)
            {
                Codigo = codigo;
                TiempoVencimiento = tiempoVencimiento;
            }
        }

    }
}
