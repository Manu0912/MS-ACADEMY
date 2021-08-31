using System;

namespace AgenciaAutos
{
    class Program
    {
        static void Main(string[] args)
        {
            Brands brand = (Brands)1;
            Console.WriteLine(brand.ToString());
            //Car exampleCar = new Car("golf",4,"red",Brands.Chevrolet,Transmition.automatic.);
            //Console.WriteLine("{0} \n {1} \n {2} \n {3} \n {4}", exampleCar.brand, exampleCar.color, exampleCar.doorsNumber, exampleCar.model, exampleCar.transmition );
            Console.WriteLine("Hello World!");
        }
    }
}
