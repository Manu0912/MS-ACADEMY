
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace AgenciaAutos.Classes
{
    class Container<T> where T : IEntity
    {
        public List<T> list { get; set; }

        public Container()
        {
            list = new();
        }

        public void Create(T item, string filePath)
        {

            if (item != null)
            {
                
                ReadJson(filePath);
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
                List<Rental> entities = JsonSerializer.Deserialize<List<Rental>>(json);
                
            }

        }

        public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }


        public T Update(T item, string filePath)
        {
            T obj = default;
            ReadJson(filePath);
            List<T> newList= new List<T>();

            list.ForEach(x =>
            {
                    if (item.Id == x.Id)
                    {
                        newList.Add(item);
                        obj = item;
                    }
                    else
                    {
                        newList.Add(x);
                    }
            });

            if (newList.Count > 0)
            {
                list = newList;
            }

            WriteFile(filePath);

            return obj;
        }

        public void Delete(int _id, string filePath)
        {
            ReadJson(filePath);
            int count = -1;
            
            list.ForEach(x =>
            {
                if (x.Id == _id)
                {
                    count = list.IndexOf(x);
                }
            });

            if (count != -1) list.RemoveAt(count);
            
            WriteFile(filePath);
        }

        public T Get(int _id, string filePath)
        {
            ReadJson(filePath);

            int count = -1;

            list.ForEach(x =>
            {
                if (x.Id == _id)
                {
                    count = list.IndexOf(x);
                }
            });

            return list[count];
        }

        public List<T> GetAll()
        {
            return list;
        }

        public string GetFilePath(string basePath)
        {
            StringBuilder sb = new();

            sb.AppendFormat("{0}{1}{2}", basePath, typeof(T).Name,".json");

            return sb.ToString();
        }
    }
}
