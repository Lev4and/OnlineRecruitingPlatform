using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CompanyContactPhone
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("companyContactId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid CompanyContactId { get; set; }

        [MaxLength(1)]
        [JsonProperty("countryCode")]
        public virtual string CountryCode { get; set; }

        [MaxLength(3)]
        [JsonProperty("cityCode")]
        public virtual string CityCode { get; set; }

        [MaxLength(7)]
        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("formatted")]
        public string Formatted { get; set; }

        [JsonProperty("companyContact")]
        public CompanyContact CompanyContact { get; set; }
    }

    public class CompanyContactPhoneIV : CompanyContactPhone
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid CompanyContactId { get; set; }

        [JsonProperty("country")]
        public override string CountryCode { get; set; }

        [JsonProperty("city")]
        public override string CityCode { get; set; }
    }
}
