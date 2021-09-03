using System;

namespace AgenciaAutos.car
{
    public class Car
    {

        public int id;
        public string model;
        public int doorsNumber;
        public string color;
        public string brand;
        public string transmition;

        public Car()
        {

        }
        public Car(string _model, int _doorsNumber, string _color, string _brand, string _transmition, int _id)
        {

            id = _id;
            model = _model;
            doorsNumber = _doorsNumber;
            color = _color;
            brand = _brand;
            transmition = _transmition;
            
        }   

    }
}
    

