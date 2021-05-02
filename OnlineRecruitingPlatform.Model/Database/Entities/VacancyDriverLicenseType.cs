using System;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancyDriverLicenseType
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        
        [JsonProperty("vacancyId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid VacancyId { get; set; }
        
        [JsonProperty("driverLicenseTypeId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid DriverLicenseTypeId { get; set; }
        
        [JsonProperty("vacancy")]
        public Vacancy Vacancy { get; set; }
        
        [JsonProperty("driverLicenseType")]
        public DriverLicenseType DriverLicenseType { get; set; }
    }
}