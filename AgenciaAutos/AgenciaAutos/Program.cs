using AgenciaAutos.car;
using CRUD;
using Enums;
using System;

namespace AgenciaAutos
{
    class Program
    {
        static void Main(string[] args)
        {
            //test create function
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

        }
    }
}
