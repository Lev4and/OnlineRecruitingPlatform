using System.Collections.Generic;
using System.Threading.Tasks;
using FIASApi.HttpClients.Clients.Addrobs;
using FIASApi.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var response = await _areasClient.GetAreas();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VArea>>(resultJson);

            ViewBag.areas = result;

            return View();
        }

        [HttpGet]
        [Route("Admin/FIAS/Areas/{aoguid}")]
        public async Task<IActionResult> DetailsArea(string aoguid)
        {
            var responseArea = await _areasClient.GetArea(aoguid);
            var resultJsonArea = await responseArea.Content.ReadAsStringAsync();
            var resultArea = JsonConvert.DeserializeObject<VArea>(resultJsonArea);

            var responseAreaCities = await _citiesClient.GetCities("_", regionCode: resultArea.Regioncode, areaCode: resultArea.Areacode);
            var responseJsonAreaCities = await responseAreaCities.Content.ReadAsStringAsync();
            var resultAreaCities = JsonConvert.DeserializeObject<List<VCity>>(responseJsonAreaCities);


            ViewBag.area = resultArea;
            ViewBag.areaCities = resultAreaCities;

            return View();
        }

        [Route("Admin/FIAS/Cities/")]
        public async Task<IActionResult> Cities()
        {
            var response = await _citiesClient.GetCities();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VCity>>(resultJson);

            ViewBag.cities = result;

            return View();
        }

        [HttpGet]
        [Route("Admin/FIAS/Cities/{aoguid}")]
        public async Task<IActionResult> DetailsCity(string aoguid)
        {
            var responseCity = await _citiesClient.GetCity(aoguid);
            var resultJsonCity = await responseCity.Content.ReadAsStringAsync();
            var resultCity = JsonConvert.DeserializeObject<VCity>(resultJsonCity);

            var responseCityPlaces = await _placesClient.GetPlaces("_", regionCode: resultCity.Regioncode, areaCode: resultCity.Areacode, cityCode: resultCity.Citycode);
            var resultJsonCityPlaces = await responseCityPlaces.Content.ReadAsStringAsync();
            var resultCityPlaces = JsonConvert.DeserializeObject<List<VPlace>>(resultJsonCityPlaces);

            ViewBag.city = resultCity;
            ViewBag.cityPlaces = resultCityPlaces;

            return View();
        }

        [Route("Admin/FIAS/Places/")]
        public async Task<IActionResult> Places()
        {
            var response = await _placesClient.GetPlaces();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VPlace>>(resultJson);

            ViewBag.places = result;

            return View();
        }

        [HttpGet]
        [Route("Admin/FIAS/Places/{aoguid}")]
        public async Task<IActionResult> DetailsPlace(string aoguid)
        {
            var responsePlace = await _placesClient.GetPlace(aoguid);
            var resultJsonPlace = await responsePlace.Content.ReadAsStringAsync();
            var resultPlace = JsonConvert.DeserializeObject<VPlace>(resultJsonPlace);

            var responsePlaceStreets = await _streetsClient.GetStreets("_", regionCode: resultPlace.Regioncode, areaCode: resultPlace.Areacode, cityCode: resultPlace.Citycode, placeCode: resultPlace.Placecode);
            var resultJsonPlaceStreets = await responsePlaceStreets.Content.ReadAsStringAsync();
            var resultPlaceStreets = JsonConvert.DeserializeObject<List<VStreet>>(resultJsonPlaceStreets);

            ViewBag.place = resultPlace;
            ViewBag.resultJsonPlaceStreets = resultPlaceStreets;

            return View();
        }

        [Route("Admin/FIAS/Regions/")]
        public async Task<IActionResult> Regions()
        {
            var response = await _regionsClient.GetRegions();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VRegion>>(resultJson);

            ViewBag.regions = result;

            return View();
        }
        
        [HttpGet]
        [Route("Admin/FIAS/Regions/{aoguid}")]
        public async Task<IActionResult> DetailsRegion(string aoguid)
        {
            var responseRegion = await _regionsClient.GetRegion(aoguid);
            var resultJsonRegion = await responseRegion.Content.ReadAsStringAsync();
            var resultRegion = JsonConvert.DeserializeObject<VRegion>(resultJsonRegion);

            var responseRegionAreas = await _areasClient.GetAreas("_", regionCode: resultRegion.Regioncode);
            var resultJsonRegionAreas = await responseRegionAreas.Content.ReadAsStringAsync();
            var resultRegionAreas = JsonConvert.DeserializeObject<List<VArea>>(resultJsonRegionAreas);

            ViewBag.region = resultRegion;
            ViewBag.regionAreas = resultRegionAreas;

            return View();
        }

        [Route("Admin/FIAS/Streets/")]
        public async Task<IActionResult> Streets()
        {
            var response = await _streetsClient.GetStreets();
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<VStreet>>(resultJson);

            ViewBag.streets = result;

            return View();
        }

        [HttpGet]
        [Route("Admin/FIAS/Streets/{aoguid}")]
        public async Task<IActionResult> DetailsStreet(string aoguid)
        {
            var response = await _streetsClient.GetStreet(aoguid);
            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<VStreet>(resultJson);

            ViewBag.street = result;

            return View();
        }
    }
}