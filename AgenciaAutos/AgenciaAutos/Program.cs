using AgenciaAutos.car;
using AgenciaAutos.CRUD;
using Enums;
using System;
using System.Text.Json;

namespace AgenciaAutos
{
    class Program
    {
        static void Main(string[] args)
        {
            //test CRUD function
            string brand = Enum.GetName(typeof(Brands), 0);
            string transmition = Enum.GetName(typeof(Transmition), 0);

            Car car = new Car("x", 5, "red", brand, transmition,01);
            CarCRUD carcrud = new CarCRUD(@"F:\cars.json");
            carcrud.Create(car);

            Car car1 = new Car("x", 5, "red", brand, transmition,02);
            
            carcrud.Create(car1);

            Car car2 = new Car("x", 5, "red", brand, transmition,03);
           
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
