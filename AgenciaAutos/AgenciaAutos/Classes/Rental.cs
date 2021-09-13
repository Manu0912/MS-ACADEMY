using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaAutos
{
    class Rental
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
