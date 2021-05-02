using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.JsonConverters;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Vacancy : IImportedFromHeadHunter<int?>, IImportedFromZarplataRu<int?>, IImportedFromAvitoRu<int?>
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid Id { get; set; }
        
        [JsonProperty("areaId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid AreaId { get; set; }
        
        [JsonProperty("address")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? AddressId { get; set; }

        [JsonProperty("scheduleId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid ScheduleId { get; set; }
        
        [JsonProperty("experienceId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid ExperienceId { get; set; }
        
        [JsonProperty("educationLevelId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? EducationLevelId { get; set; }
        
        [JsonProperty("employmentId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? EmploymentId { get; set; }
        
        [JsonProperty("vacancyTypeId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid VacancyTypeId { get; set; }
        
        [JsonProperty("companyId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? CompanyId { get; set; }

        [JsonProperty("workingDaysId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? WorkingDaysId { get; set; }
        
        [JsonProperty("workingTimeIntervalsId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? WorkingTimeIntervalsId { get; set; }
        
        [JsonProperty("workingTimeModesId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? WorkingTimeModesId { get; set; }
        
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("archived")]
        public bool Archived { get; set; }
        
        [JsonProperty("acceptTemporary")]
        public bool? AcceptTemporary { get; set; }
        
        [JsonProperty("acceptHandicapped")]
        public bool AcceptHandicapped { get; set; }
        
        [JsonProperty("acceptKids")]
        public bool AcceptKids { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("publishedAt")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public int? IdentifierFromHeadHunter { get; set; }

        [JsonProperty("identifierFromZarplataRu")]
        public int? IdentifierFromZarplataRu { get; set; }

        [JsonProperty("identifierFromAvitoRu")]
        public int? IdentifierFromAvitoRu { get; set; }

        [JsonProperty("vacancyInformation")]
        public VacancyInformation VacancyInformation { get; set; }
        
        [JsonProperty("area")]
        public Area Area { get; set; }
        
        [JsonProperty("address")]
        public Address Address { get; set; }
        
        [JsonProperty("schedule")]
        public Schedule Schedule { get; set; }
        
        [JsonProperty("experience")]
        public Experience Experience { get; set; }
        
        [JsonProperty("educationLevel")]
        public EducationLevel EducationLevel { get; set; }
        
        [JsonProperty("employment")]
        public Employment Employment { get; set; }
        
        [JsonProperty("vacancyType")]
        public VacancyType VacancyType { get; set; }
        
        [JsonProperty("vacancySalary")]
        public VacancySalary VacancySalary { get; set; }
        
        [JsonProperty("vacancyContact")]
        public VacancyContact VacancyContact { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("workingDays")]
        public WorkingDays WorkingDays { get; set; }
        
        [JsonProperty("workingTimeIntervals")]
        public WorkingTimeIntervals WorkingTimeIntervals { get; set; }
        
        [JsonProperty("workingTimeModes")]
        public WorkingTimeModes WorkingTimeModes { get; set; }
        
        [JsonProperty("vacancyKeySkills")]
        public VacancyKeySkill[] VacancyKeySkills { get; set; }
        
        [JsonProperty("vacancySpecializations")]
        public VacancySpecialization[] VacancySpecializations { get; set; }
        
        [JsonProperty("vacancyDriverLicenseType")]
        public VacancyDriverLicenseType[] VacancyDriverLicenseTypes { get; set; }
    }
}