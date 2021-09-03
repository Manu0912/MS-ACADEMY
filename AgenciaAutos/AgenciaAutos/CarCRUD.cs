using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using AgenciaAutos.car;

namespace CRUD
{
	public class CarCRUD
	{
		private string filePath;
		private List<Car> cars;

		public CarCRUD(string _filePath)
		{
			filePath = _filePath;
			cars = new List<Car>();
		}

		public void Create(Car car)
		{
         
            if (car !=null)
            {
				ReadJson();
				cars.Add(car);
				WriteFile();
			}
			
		}

		public void WriteFile()
		{
			var options = new JsonSerializerOptions { WriteIndented = true };

			string json = JsonSerializer.Serialize(cars, options);

			using (var writer = new StreamWriter(filePath))
			{
				writer.Write(json);
			}
			Console.WriteLine(json);
		}

		public void ReadJson()
		{
			cars = new List<Car>();
			string json = "";

			if (File.Exists(filePath))
            {
				json = ReadFile();
            }
			

			if (!string.IsNullOrEmpty(json))
			{
				cars = (List<Car>)JsonSerializer.Deserialize(json, typeof(List<Car>));
			}

		}	
		public string ReadFile()
		{
			return File.ReadAllText(filePath);
		}

		public Car Get(int _id)
        {
			ReadJson();
			return cars.Find(x => x.id == _id);
        }

		public Car Update(Car car)
		{
			Car obj = null;
			ReadJson();
			cars.ForEach(x => { 
				if(x.id == car.id)
                {
					obj = x;
					x.brand = car.brand;
					x.color = car.color;
					x.doorsNumber = car.doorsNumber;
					x.model = car.model;
					x.transmition = car.transmition;
                }
			});
			WriteFile();

			return obj;
		}

		public void Delete(int id)
		{
			Car car = new Car();
			ReadJson();
			cars.ForEach(x => 
			{
				if (x.id == id) car = x; 
			});
			cars.Remove(car);
			WriteFile();
		}
	}
}


	



