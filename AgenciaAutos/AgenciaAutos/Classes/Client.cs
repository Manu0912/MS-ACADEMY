using System;

namespace AgenciaAutos
{
    class Client
    {
        public int dni { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string telephoneNumber { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int postalCode { get; set; }
        public DateTime lastModified { get; set; }

        Client()
        {

        }
        Client(int _dni,string _name, string _lastname, string _telephoneNumber, string _address, string _city, string _state, int _postalCode, DateTime _lastModified)
        {
            dni = _dni;
            name = _name;
            lastName = _lastname;
            telephoneNumber = _telephoneNumber;
            address = _address;
            city = _city;
            state = _state;
            postalCode = _postalCode;
            lastModified = _lastModified;
        }
    }
}
