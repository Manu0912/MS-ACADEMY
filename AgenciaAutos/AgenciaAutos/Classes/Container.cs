using AgenciaAutos.car;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AgenciaAutos.Classes
{
    class Container<T>
    {
        private List<T> list;

		public Container()
		{
			list = new();
		}

		public void Create(T item, string filePath)
		{

			if (item != null)
			{
				list.Add(item);
				WriteFile(filePath);
			}

		}

		public void WriteFile(string filePath)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };

			string json = JsonSerializer.Serialize(list, options);

			using (StreamWriter sw = new StreamWriter(filePath))
			{
				sw.Write(json);
				sw.Close();
			}

		}

		public void ReadJson(string filePath)
		{
			list = new List<T>();
			string json = "";

			if (File.Exists(filePath))
			{
				json = ReadFile(filePath);
			}

			if (!string.IsNullOrEmpty(json))
			{
				list = (List<T>)JsonSerializer.Deserialize(json, typeof(List<T>));
			}

		}

		public string ReadFile(string filePath)
		{
			return File.ReadAllText(filePath);
		}

	}
}
