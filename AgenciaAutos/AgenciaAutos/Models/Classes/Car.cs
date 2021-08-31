using System;


    public class Car
    {

        public string model { get; set; }
        public int doorsNumber { get; set; }
        public string color { get; set; }
        public string brand { get; set; }
        public string transmition { get; set; }

        public Car(string _model, int _doorsNumber, string _color, string _brand, string _transmition)
        {
            model = _model;
            doorsNumber = _doorsNumber;
            color = _color;
            brand = _brand;
            transmition = _transmition;
        }

    }

