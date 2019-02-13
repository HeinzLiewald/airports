using Service.Models;
using System.Linq;
using System.Web.Mvc;
using Web.Util;

namespace Web.Controllers {
    public class AirportController : CognizantController {

        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        [IncludeFeedTime]
        public JsonResult GetAirports() {
            Service.AirportService.Airports = null; //Forced clean to retrieve new data

            var allAirports = Service.AirportService.Airports;

            var europeanAirports = (from airport in allAirports
                                    where airport.Type == Airport.TYPE_AIRPORT && airport.Continent == Airport.CONTINENT_EU
                                    select airport).ToList();

            var distinctAirports = europeanAirports.Select(airport => airport.Iso).Distinct().ToList();

            return Json(new {
                success = true,
                ListAirports = RenderRazorViewToString("_ListAirports", europeanAirports),
                FilterAirport = RenderRazorViewToString("_FilterAirport", distinctAirports)
            });
        }

        [HttpGet]
        public ActionResult DistanceBetween(string iataOrigin, string iataDestination) {
            var distance = Service.AirportService.DistanceBetween(iataOrigin, iataDestination);

            ViewBag.DistanceBetweenMessage = $"The distance between {iataOrigin} and {iataDestination} is {distance} kilometers";

            return View(model: null);
        }
    }
}