using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAirport.Model
{
    internal class PassengerModel
    {
        public required string FlightNumber { get; set; }
        public DateTime Departure { get; set; }
        public required string FirstName { get; set; }
        public required string Name { get; set; }
        public string? Patronymic { get; set; }
    }
}
