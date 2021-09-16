using AgenciaAutos.Classes;

namespace AgenciaAutos.car 
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string model { get; set; }
        public int doorsNumber { get; set; }
        public string color { get; set; }
        public string brand { get; set; }
        public string transmition { get; set; }

        public Car(string _model, int _doorsNumber, string _color, string _brand, string _transmition, int _id)
        {

            Id = _id;
            model = _model;
            doorsNumber = _doorsNumber;
            color = _color;
            brand = _brand;
            transmition = _transmition;
        }  
    }
}
    
