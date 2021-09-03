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

			var json = ReadFile();

			if (!string.IsNullOrEmpty(json))
			{
				cars = (List<Car>)JsonSerializer.Deserialize(json, typeof(List<Car>));
			}

		}	
		public string ReadFile()
		{
			return File.ReadAllText(filePath);
		}

	}
}


	



