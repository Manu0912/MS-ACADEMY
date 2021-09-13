using AgenciaAutos.car;
using AgenciaAutos.CRUD;
using Enums;
using System;
using System.Text.Json;
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
            Car item = new Car("asdasdjasd", 7, "black", "pepea", "manual", 2);


            //cars.Create(item, CRUDOptions.CarsPATH);
            cars.Update(item,CRUDOptions.CarsPATH);
            Console.WriteLine(cars.ReadFile(CRUDOptions.CarsPATH));

            //TestCrud();
            cars.Delete(2, CRUDOptions.CarsPATH);
            Console.WriteLine(cars.ReadFile(CRUDOptions.CarsPATH));

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

        static void TestCrud(){
            //test CRUD function

            string brand = Enum.GetName(typeof(Brands), 0);
            string transmition = Enum.GetName(typeof(Transmition), 0);

            Car car = new Car("x", 5, "red", brand, transmition, 01);
            CarCRUD carcrud = new CarCRUD(CRUDOptions.CarsPATH);
            carcrud.Create(car);

            Car car1 = new Car("x", 5, "red", brand, transmition, 02);

            carcrud.Create(car1);

            Car car2 = new Car("x", 5, "red", brand, transmition, 03);

            carcrud.Create(car2);

            string read = carcrud.ReadFile();

            Console.WriteLine(read);

            car2.model = "y";
            carcrud.Update(car2);

            read = carcrud.ReadFile();
            Console.WriteLine(read);

            carcrud.Delete(1);

            read = carcrud.ReadFile();
            Console.WriteLine(read);

            var options = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(carcrud.Get(2), options);
            Console.WriteLine(json);
        }

        

    }
}
