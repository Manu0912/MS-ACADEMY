using AgenciaAutos.car;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using AgenciaAutos.Options;
using System.Threading.Tasks;
using AgenciaAutos.Classes;

namespace AgenciaAutos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            Container<Car> cars = new Container<Car>();
            Container<Rental> rentals = new Container<Rental>();
            Container<Client> clients = new Container<Client>();

            //TEST FUNCTIONS HERE

            //END TEST FUNCTIONS

            await host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();

                    IHostEnvironment env = hostingContext.HostingEnvironment;

                    configuration
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

                    IConfigurationRoot configurationRoot = configuration.Build();

                    TransientFaultHandlingOptions options = new();
                    configurationRoot.GetSection(nameof(TransientFaultHandlingOptions))
                                     .Bind(options);

                    CRUDOptions crudOptions = new();
                    configurationRoot.GetSection(nameof(CRUDOptions))
                                     .Bind(crudOptions);
                });

       
        
            

    }
}
