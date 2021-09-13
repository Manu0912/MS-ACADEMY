using AgenciaAutos.car;
using AgenciaAutos.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AgenciaAutos.Classes
{
    class Container<T>
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
                list = (List<T>)JsonSerializer.Deserialize(json, typeof(List<T>));
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

            List<Car> cars = new List<Car>();
            List<Rental> rentals = new List<Rental>();
            List<Client> clients = new List<Client>();

            list.ForEach(x =>
            {
                if (x.GetType() == typeof(Car))
                {
                    Car y = (Car)(object)x;
                    Car updated = (Car)(object)item;


                    if (y.id == updated.id)
                    {
                        cars.Add(updated);
                        obj = (T)(object)updated;
                    }
                    else
                    {
                        cars.Add(y);
                    }
                }else if (x.GetType() == typeof(Rental))
                {
                    Rental y = (Rental)(object)x;
                    Rental updated = (Rental)(object)item;
                    

                    if (y.id == updated.id)
                    {
                        rentals.Add(updated);
                        obj = (T)(object)updated;
                    }
                    else
                    {
                        rentals.Add(y);
                    }
                }
                else if (x.GetType() == typeof(Client))
                {
                    Client y = (Client)(object)x;
                    Client updated = (Client)(object)item;


                    if (y.dni == updated.dni)
                    {
                        updated.lastModified = new DateTime();
                        clients.Add(updated);
                        obj = (T)(object)updated;
                    }
                    else
                    {
                        clients.Add(y);
                    }
                }
            });

            if (cars.Count > 0)
            {
                if(item.GetType() == typeof(Car))
                {
                    list = (List<T>)(object)cars;
                }
                else if(item.GetType() == typeof(Rental))
                {
                    list = (List<T>)(object)rentals;
                }
                else if (item.GetType() == typeof(Client))
                {
                    list = (List<T>)(object)clients;
                }

            }

            WriteFile(filePath);

            return obj;
        }

        public void Delete(int id, string filePath)
        {
            Car car = new Car();
            ReadJson(filePath);
            int count = -1;
            
            list.ForEach(x =>
            {
                if (x.GetType() == typeof(Car))
                {
                    Car y = (Car)(object)x;

                    if (y.id == id)
                    {
                        count = list.IndexOf(x);
                    }

                }else if (x.GetType() == typeof(Client))
                {
                    Client y = (Client)(object)x;

                    if (y.dni == id)
                    {
                        count = list.IndexOf(x);
                    }

                }else if (x.GetType() == typeof(Rental))
                {
                    Rental y = (Rental)(object)x;

                    if (y.id == id)
                    {
                        count = list.IndexOf(x);
                    }
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
                if (x.GetType() == typeof(Car))
                {
                    Car y = (Car)(object)x;
                    if (y.id == _id)
                    {
                        count = list.IndexOf(x);
                    }
                }else if (x.GetType() == typeof(Rental))
                {
                    Rental y = (Rental)(object)x;
                    if (y.id == _id)
                    {
                        count = list.IndexOf(x);
                    }
                }
            });

            return list[count];
        }

        public List<T> GetAll()
        {
            return list;
        }
    }
}
