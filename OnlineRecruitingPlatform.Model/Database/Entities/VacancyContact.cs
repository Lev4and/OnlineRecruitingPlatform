using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class VacancyContact
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("vacancyId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid VacancyId { get; set; }
        
        [JsonProperty("addressId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public virtual Guid? AddressId { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }
        
        [JsonProperty("skype")]
        public string Skype { get; set; }
        
        [JsonProperty("vacancy")]
        public Vacancy Vacancy { get; set; }
        
        [JsonProperty("address")]
        public virtual Address Address { get; set; }
        
        [JsonProperty("vacancyContactPhones")]
        public virtual ICollection<VacancyContactPhone> VacancyContactPhones { get; set; }
    }

    public class VacancyContactIV : VacancyContact
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid VacancyId { get; set; }

        [JsonProperty("phones")]
        public VacancyContactPhoneIV[] Phones { get; set; }

        [JsonProperty()]
        public override ICollection<VacancyContactPhone> VacancyContactPhones { get; set; }
    }

    public class VacancyContactIVZarplataRu : VacancyContact
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid VacancyId { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid? AddressId { get; set; }

        [JsonProperty("street")]
        public string StreetName { get; set; }

        [JsonProperty("building")]
        public string BuildingName { get; set; }

        [JsonProperty("address")]
        public string ContactAddress { get; set; }

        [JsonProperty("city")]
        public AreaIVZarplataRu City { get; set; }

        [JsonProperty()]
        public override Address Address { get; set; }

        [JsonProperty("phones")]
        public VacancyContactPhoneIV[] Phones { get; set; }

        [JsonProperty()]
        public override ICollection<VacancyContactPhone> VacancyContactPhones { get; set; }
    }
}