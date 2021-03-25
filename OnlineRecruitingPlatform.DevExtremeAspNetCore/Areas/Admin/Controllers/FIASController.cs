using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FIASApi.Response.RestClients.Addrobs;
using FIASApi.Response.RestClients.Houses;
using FIASApi.Response.RestClients.Rooms;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FIASController : Controller
    {
        private readonly AreasRestClient _areasRestClient;
        private readonly FlatsRestClient _flatsRestClient;
        private readonly CitiesRestClient _citiesRestClient;
        private readonly PlacesRestClient _placesRestClient;
        private readonly HousesRestClient _housesRestClient;
        private readonly RegionsRestClient _regionsRestClient;
        private readonly StreetsRestClient _streetsRestClient;
        private readonly OfficesRestClient _officesRestClient;

        public FIASController(AreasRestClient areasRestClient, FlatsRestClient flatsRestClient, CitiesRestClient citiesRestClient, PlacesRestClient placesRestClient, HousesRestClient housesRestClient, RegionsRestClient regionsRestClient, StreetsRestClient streetsRestClient, OfficesRestClient officesRestClient)
        {
            _areasRestClient = areasRestClient;
            _flatsRestClient = flatsRestClient;
            _citiesRestClient = citiesRestClient;
            _placesRestClient = placesRestClient;
            _housesRestClient = housesRestClient;
            _regionsRestClient = regionsRestClient;
            _streetsRestClient = streetsRestClient;
            _officesRestClient = officesRestClient;
        }

        [Route("Admin/FIAS/Regions/")]
        public async Task<IActionResult> Regions()
        {
            ViewBag.regions = await _regionsRestClient.GetRegions();

            return View();
        }

        [Route("Admin/FIAS/Areas/")]
        public async Task<IActionResult> Areas()
        {
            ViewBag.areas = await _areasRestClient.GetAreas();

            return View();
        }

        [Route("Admin/FIAS/Places/")]
        public async Task<IActionResult> Places()
        {
            ViewBag.places = await _placesRestClient.GetPlaces();

            return View();
        }

        [Route("Admin/FIAS/Cities")]
        public async Task<IActionResult> Cities()
        {
            ViewBag.cities = await _citiesRestClient.GetCities();

            return View();
        }

        [Route("Admin/FIAS/Streets/")]
        public async Task<IActionResult> Streets()
        {
            ViewBag.streets = await _streetsRestClient.GetStreets();

            return View();
        }
    }
}
