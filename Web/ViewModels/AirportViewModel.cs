using Service.Models;
using System.Collections.Generic;

namespace Web.ViewModels {
    public class AirportViewModel {
        public List<Airport> ListAirport { get; set; }
        public List<string> ListCountry { get; set; }
    }
}