using AgenciaAutos.car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaAutos.Interfaces
{
    interface ICRUD
    {
        public void Create(Car car);
        public void WriteFile();
        public void ReadJson();
        public string ReadFile();
        public Car Get(int _id);
        public Car Update(Car car);
        public void Delete(int id);
    }
}
