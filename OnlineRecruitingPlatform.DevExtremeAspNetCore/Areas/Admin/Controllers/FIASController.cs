using FIASApi.HttpClients.Clients.Addrobs;
using FIASApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Domain.Converters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FIASController : Controller
    {
        private readonly AreasClient _areasClient;
        private readonly CitiesClient _citiesClient;
        private readonly PlacesClient _placesClient;
        private readonly RegionsClient _regionsClient;
        private readonly StreetsClient _streetsClient;
        
        public FIASController(AreasClient areasClient, CitiesClient citiesClient, PlacesClient placesClient, RegionsClient regionsClient, StreetsClient streetsClient)
        {
            _areasClient = areasClient;
            _citiesClient = citiesClient;
            _placesClient = placesClient;
            _regionsClient = regionsClient;
            _streetsClient = streetsClient;
        }
        
        [Route("Admin/FIAS/Areas/")]
        public async Task<IActionResult> Areas()
        {
            ViewBag.areas = ResponseConverter.Convert<List<VArea>>(await _areasClient.GetAreas());

            return View();
        }

        [HttpGet]
        [Route("Admin/FIAS/Areas/{aoguid}")]
        public async Task<IActionResult> DetailsArea(string aoguid)
        {
            ViewBag.area = ResponseConverter.Convert<VArea>(await _areasClient.GetArea(aoguid));
            ViewBag.areaCities = ResponseConverter.Convert<List<VCity>>(await _citiesClient.GetCities("_", regionCode: ViewBag.area.Regioncode, areaCode: ViewBag.area.Areacode));

            return View();
        }

        [Route("Admin/FIAS/Cities/")]
        public async Task<IActionResult> Cities()
        {
            ViewBag.cities = ResponseConverter.Convert<List<VCity>>(await _citiesClient.GetCities());

            return View();
        }

        [HttpGet]
        [Route("Admin/FIAS/Cities/{aoguid}")]
        public async Task<IActionResult> DetailsCity(string aoguid)
        {
            ViewBag.city = ResponseConverter.Convert<VCity>(await _citiesClient.GetCity(aoguid));
            ViewBag.cityPlaces = ResponseConverter.Convert<List<VPlace>>(await _placesClient.GetPlaces("_", regionCode: ViewBag.city.Regioncode, areaCode: ViewBag.city.Areacode, cityCode: ViewBag.city.Citycode));

            return View();
        }

        [Route("Admin/FIAS/Places/")]
        public async Task<IActionResult> Places()
        {
            ViewBag.places = ResponseConverter.Convert<List<VPlace>>(await _placesClient.GetPlaces());

            return View();
        }

        [HttpGet]
        [Route("Admin/FIAS/Places/{aoguid}")]
        public async Task<IActionResult> DetailsPlace(string aoguid)
        {
            ViewBag.place = ResponseConverter.Convert<VPlace>(await _placesClient.GetPlace(aoguid));
            ViewBag.placeStreets = ResponseConverter.Convert<List<VStreet>>(await _streetsClient.GetStreets("_", regionCode: ViewBag.place.Regioncode, areaCode: ViewBag.place.Areacode, cityCode: ViewBag.place.Citycode, placeCode: ViewBag.place.Placecode));

            return View();
        }

        [Route("Admin/FIAS/Regions/")]
        public async Task<IActionResult> Regions()
        {
            ViewBag.regions = ResponseConverter.Convert<List<VRegion>>(await _regionsClient.GetRegions());

            return View();
        }
        
        [HttpGet]
        [Route("Admin/FIAS/Regions/{aoguid}")]
        public async Task<IActionResult> DetailsRegion(string aoguid)
        {
            ViewBag.region = ResponseConverter.Convert<VRegion>(await _regionsClient.GetRegion(aoguid));
            ViewBag.regionAreas = ResponseConverter.Convert<List<VArea>>(await _areasClient.GetAreas("_", regionCode: ViewBag.region.Regioncode));

            return View();
        }

        [Route("Admin/FIAS/Streets/")]
        public async Task<IActionResult> Streets()
        {
            ViewBag.streets = ResponseConverter.Convert<List<VStreet>>(await _streetsClient.GetStreets());

            return View();
        }

        [HttpGet]
        [Route("Admin/FIAS/Streets/{aoguid}")]
        public async Task<IActionResult> DetailsStreet(string aoguid)
        {
            ViewBag.street = ResponseConverter.Convert<VStreet>(await _streetsClient.GetStreet(aoguid));

            return View();
        }
    }
}