using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class BusinessTripReadinessTypesDirectory
    {
        [JsonProperty("business_trip_readiness")]
        public BusinessTripReadiness[] BusinessTripReadinessTypes { get; set; }
    }

    public class BusinessTripReadinessTypesDirectory<T> where T : BusinessTripReadiness
    {
        [JsonProperty("business_trip_readiness")]
        public T[] BusinessTripReadinessTypes { get; set; }
    }
}
