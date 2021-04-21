using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class DriverLicenseTypesDirectory
    {
        [JsonProperty("driver_license_types")]
        public DriverLicenseType[] DriverLicenseTypes { get; set; }
    }

    public class DriverLicenseTypesDirectory<T> where T : DriverLicenseType
    {
        [JsonProperty("driver_license_types")]
        public T[] DriverLicenseTypes { get; set; }
    }
}
