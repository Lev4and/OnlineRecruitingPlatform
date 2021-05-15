using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.Collections.Generic;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CompanyContact : IImportedFromZarplataRu<int?>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("companyId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid CompanyId { get; set; }

        [JsonProperty("addressId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public virtual Guid AddressId { get; set; }

        [JsonProperty("identifierFromZarplataRu")]
        public virtual int? IdentifierFromZarplataRu { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("address")]
        public virtual Address Address { get; set; }

        [JsonProperty("companyContactPhones")]
        public virtual ICollection<CompanyContactPhone> CompanyContactPhones { get; set; }
    }

    public class CompanyContactIVZarplataRu : CompanyContact
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid CompanyId { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public override Guid AddressId { get; set; }

        [JsonProperty("street")]
        public string StreetName { get; set; }

        [JsonProperty("building")]
        public string BuildingName { get; set; }

        [JsonProperty("city")]
        public AreaIVZarplataRu City { get; set; }

        [JsonProperty()]
        public override Address Address { get; set; }

        [JsonProperty("phones")]
        public CompanyContactPhoneIV[] Phones { get; set; }

        [JsonProperty()]
        public override ICollection<CompanyContactPhone> CompanyContactPhones { get; set; }
    }
}
