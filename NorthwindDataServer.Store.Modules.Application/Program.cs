using Autofac.Core;
using Nancy.Hosting.Self;
using System;
using AC0KG.WindowsService;

namespace NorthwindDataServer.Store.Modules.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            if (NorthwindDataService.ProcessInstallOptions(args))
                return;

            const string escapeString = "/Terminate";

            var configuration = new StoreServiceApplicationConfiguration();

            var hostConfiguration = new HostConfiguration()
            {
                RewriteLocalhost = false,
                UrlReservations = new UrlReservations() { CreateAutomatically = true }
            };

            using (var server = new NancyHost(new Uri(string.Format("{0}/", configuration.StoreServiceQualifiedUrl)), new NancyBootstrapper(), hostConfiguration))
            {
                #region Old
                server.Start();

                Console.WriteLine("Nancy {0} adresinden dinlemede!", configuration.StoreServiceQualifiedUrl);

                Console.WriteLine("Kapatmak için bir " + escapeString + " giriniz...");

                do Console.Write("> "); while (Console.ReadLine() != escapeString);

                server.Stop(); 
                #endregion

                //NorthwindDataService.StartService<NorthwindDataService>(server.Start, null, Environment.UserInteractive);
            }
        }
    }
}
