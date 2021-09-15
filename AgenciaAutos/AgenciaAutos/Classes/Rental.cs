using AgenciaAutos.Classes;
using System;

namespace AgenciaAutos
{
    class Rental : Entity
    {
        public int id { get; set; }
        public string rentalDuration { get; set; }
        public string clientDni { get; set; }
        public string carRentalId { get; set; }
        public DateTime returnedDate { get; set; }

        public Rental()
        {

        }
        public Rental(int _id, string _rentalDuration, string _clientDni, string _carRentalId, DateTime _returnedDate)
        {
            id = _id;
            rentalDuration = _rentalDuration;
            clientDni = _clientDni;
            carRentalId = _carRentalId;
            returnedDate = _returnedDate;
        }
    }
}
