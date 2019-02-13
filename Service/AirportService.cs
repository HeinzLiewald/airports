using Service.Models;
using Service.Util;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Service {
    public static class AirportService {

        private const string URL = "https://raw.githubusercontent.com/jbrooksuk/JSON-Airports/master/airports.json";

        private static List<Airport> _airports;
        public static List<Airport> Airports {
            get {
                if (_airports == null) {
                    Task.WaitAll(Task.Run(
                        async () => { _airports = await CognizantHttpClient.GetAsync<List<Airport>>(URL, parameters: null); }
                    ));
                }
                return _airports;
            }
            set {
                _airports = value;
            }
        }

        public static double DistanceBetween(string iataOrigin, string iataDestination) {
            iataOrigin.CheckIfIsNull("IATA Origin");
            iataDestination.CheckIfIsNull("IATA Destination");

            var airportOrigin = Airports.Where(x => x.Iata == iataOrigin).FirstOrDefault();
            if (airportOrigin == null) {
                throw new AirportNotFoundException(iataOrigin);
            }

            var airportDestination = Airports.Where(x => x.Iata == iataDestination).FirstOrDefault();
            if (airportDestination == null) {
                throw new AirportNotFoundException(iataDestination);
            }

            //Origin
            var latOrigin = double.Parse(airportOrigin.Lat, CultureInfo.InvariantCulture);
            var lonOrigin = double.Parse(airportOrigin.Lon, CultureInfo.InvariantCulture);
            var coordOrigin = new GeoCoordinate(latOrigin, lonOrigin);

            //Destination
            var latDestination = double.Parse(airportDestination.Lat, CultureInfo.InvariantCulture);
            var lonDestination = double.Parse(airportDestination.Lon, CultureInfo.InvariantCulture);
            var coordDestination = new GeoCoordinate(latDestination, lonDestination);

            var distanceKilometers = Math.Round(coordOrigin.GetDistanceTo(coordDestination) / 1000, 2);

            return distanceKilometers;
        }
    }
}
