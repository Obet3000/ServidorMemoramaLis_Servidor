using ServidorMemoramaLis.Contracts;
using System;
using System.ServiceModel;
using System.Threading;

namespace ServidorMemoramaLis_Servidor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando servicios");
            ServiceHost host1 = new ServiceHost(typeof(AutentificacionServicio));
            ServiceHost host2 = new ServiceHost(typeof(ServicioChat));
            host1.Open();
            host2.Open();
            Console.WriteLine("Servicios iniciados");

            Console.ReadLine();
            host2.Close();
            host1.Close();
        }
    }
}
