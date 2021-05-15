using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;
using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CompanyPhoto : IImportedFromZarplataRu<int?>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty("companyId")]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid CompanyId { get; set; }

        [Required]
        [JsonProperty("photo")]
        public virtual string Photo { get; set; }

        [JsonProperty("identifierFromZarplataRu")]
        public virtual int? IdentifierFromZarplataRu { get; set; }

        [JsonProperty("company")] 
        public Company Company { get; set; }
    }

    public class CompanyPhotoIVZarplataRu : CompanyPhoto
    {
        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid Id { get; set; }

        [JsonProperty()]
        [JsonConverter(typeof(GuidConverter))]
        public virtual Guid CompanyId { get; set; }

        [JsonProperty("url")]
        [JsonConverter(typeof(Base64Converter))]
        public override string Photo { get; set; }

        [JsonProperty("id")]
        public override int? IdentifierFromZarplataRu { get; set; }
    }
}
