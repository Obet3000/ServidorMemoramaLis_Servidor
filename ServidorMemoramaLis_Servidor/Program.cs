using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServidorMemoramaLis_Servidor
{
    internal class program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(AutentificacionServicio)))
            {
                host.Open();
                Console.WriteLine("El servicio está en funcionamiento. Presiona Enter para detenerlo.");
                Console.ReadLine();
            }
        }
    }
}
