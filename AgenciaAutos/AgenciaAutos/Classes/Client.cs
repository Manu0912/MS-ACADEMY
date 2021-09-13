using System;

namespace AgenciaAutos
{
    class Client
    {
        private int dni { get; set; }
        private string name { get; set; }
        private string lastName { get; set; }
        private string telephoneNumber { get; set; }
        private string address { get; set; }
        private string city { get; set; }
        private string state { get; set; }
        private int postalCode { get; set; }
        private DateTime lastModified { get; set; }

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
