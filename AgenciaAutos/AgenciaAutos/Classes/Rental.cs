using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaAutos
{
    class Rental
    {
        private string rentalDuration { get; set; }
        private string clientDni { get; set; }
        private string carRentalId { get; set; }
        private DateTime returnedDate { get; set; }

        Rental(string _rentalDuration, string _clientDni, string _carRentalId, DateTime _returnedDate)
        {
            rentalDuration = _rentalDuration;
            clientDni = _clientDni;
            carRentalId = _carRentalId;
            returnedDate = _returnedDate;
        }
    }
}
