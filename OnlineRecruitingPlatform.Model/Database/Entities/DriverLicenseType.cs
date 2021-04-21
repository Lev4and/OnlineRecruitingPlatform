using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class DriverLicenseType : IImportedFromHeadHunter<string>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [Required]
        [JsonProperty("name")]
        [JsonConverter(typeof(UpperRegisterConverter))]
        public string Name { get; set; }

        [JsonProperty("identifierfromheadhunter")]
        [JsonConverter(typeof(UpperRegisterConverter))]
        public virtual string IdentifierFromHeadHunter { get; set; }
    }

    public class DriverLicenseTypeIV : DriverLicenseType
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(UpperRegisterConverter))]
        public override string IdentifierFromHeadHunter { get; set; }
    }
}
