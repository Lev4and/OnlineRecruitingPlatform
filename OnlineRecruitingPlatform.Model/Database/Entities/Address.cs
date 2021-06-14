using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Address : ISupportAssociationWithFIAS
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }
        
        [JsonProperty("aoguid")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public virtual Guid? Aoguid { get; set; }
        
        [JsonProperty("cityId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public virtual Guid? CityId { get; set; }
        
        [JsonProperty("streetId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public virtual Guid? StreetId { get; set; }
        
        [JsonProperty("buildingId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public virtual Guid? BuildingId { get; set; }
        
        [JsonProperty("cityName")]
        public virtual string CityName { get; set; }
        
        [JsonProperty("streetName")]
        public virtual string StreetName { get; set; }
        
        [JsonProperty("buildingName")]
        public virtual string BuildingName { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("latitude")]
        public virtual double? Latitude { get; set; }
        
        [JsonProperty("longitude")]
        public virtual double? Longitude { get; set; }
        
        [JsonProperty("area")]
        public Area Area { get; set; }
        
        [JsonProperty("street")]
        public Street Street { get; set; }
        
        [JsonProperty("building")]
        public Building Building { get; set; }
        
        [JsonProperty("vacancies")]
        public ICollection<Vacancy> Vacancies { get; set; }

        [JsonProperty("companyContacts")]
        public ICollection<CompanyContact> CompanyContacts { get; set; }
        
        [JsonProperty("vacancyContacts")]
        public ICollection<VacancyContact> VacancyContacts { get; set; }

        public string GetStringFullAddress()
        {
            return $"{CityName}, {StreetName}, {BuildingName}";
        }
    }

    public class AddressIV : Address
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid? Aoguid { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid? CityId { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid? StreetId { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid? BuildingId { get; set; }

        [JsonProperty("city")]
        public override string CityName { get; set; }

        [JsonProperty("street")]
        public override string StreetName { get; set; }

        [JsonProperty("building")]
        public override string BuildingName { get; set; }

        [JsonProperty("lat")]
        public override double? Latitude { get; set; }

        [JsonProperty("lng")]
        public override double? Longitude { get; set; }
    }

    public class AddressIVZarplataRu : Address
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid? Aoguid { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid? CityId { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid? StreetId { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid? BuildingId { get; set; }

        [JsonProperty("street")]
        public override string StreetName { get; set; }

        [JsonProperty("building")]
        public override string BuildingName { get; set; }
        
        [JsonProperty("city")]
        public AreaIVZarplataRu City { get; set; }
    }
}