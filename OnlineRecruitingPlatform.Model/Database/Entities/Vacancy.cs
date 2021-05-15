using System;
using System.Collections.Generic;
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
        public Guid? AreaId { get; set; }
        
        [JsonProperty("address")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? AddressId { get; set; }

        [JsonProperty("scheduleId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? ScheduleId { get; set; }
        
        [JsonProperty("experienceId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? ExperienceId { get; set; }
        
        [JsonProperty("educationLevelId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? EducationLevelId { get; set; }
        
        [JsonProperty("employmentId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? EmploymentId { get; set; }

        [JsonProperty("agePreferenceId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? AgePreferenceId { get; set; }

        [JsonProperty("vacancyTypeId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid? VacancyTypeId { get; set; }
        
        [JsonProperty("vacancyVisibilityTypeId")]
        public Guid? VacancyVisibilityTypeId { get; set; }

        [JsonProperty("professionId")]
        [JsonConverter(typeof(GuidConverter))]
        public Guid? ProfessionId { get; set; }

        [JsonProperty("payPeriodId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? PayPeriodId { get; set; }

        [JsonProperty("payoutFrequencyId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? PayoutFrequencyId { get; set; }

        [JsonProperty("companyId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? CompanyId { get; set; }

        [JsonProperty("placeOfWorkId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? PlaceOfWorkId { get; set; }

        [JsonProperty("professionalAreaId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? ProfessionalAreaId { get; set; }

        [JsonProperty("workingDaysId")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? WorkingDaysId { get; set; }

        [JsonProperty("workingShift")]
        [JsonConverter(typeof(GuidNullableConverter))]
        public Guid? WorkingShiftId { get; set; }
        
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

        [JsonProperty("acceptStudent")]
        public bool? AcceptStudent { get; set; }
        
        [JsonProperty("remoteInterview")]
        public bool? RemoteInterview { get; set; }

        [JsonProperty("acceptPensioner")]
        public bool? AcceptPensioner { get; set; }
        
        [JsonProperty("acceptTemporary")]
        public bool? AcceptTemporary { get; set; }
        
        [JsonProperty("acceptHandicapped")]
        public bool? AcceptHandicapped { get; set; }
        
        [JsonProperty("acceptKids")]
        public bool? AcceptKids { get; set; }

        [JsonProperty("piecework")]
        public bool? Piecework { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }
        
        [JsonProperty("modifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
        
        [JsonProperty("publishedAt")]
        public DateTime? PublishedAt { get; set; }

        [JsonProperty("identifierFromHeadHunter")]
        public int? IdentifierFromHeadHunter { get; set; }

        [JsonProperty("identifierFromZarplataRu")]
        public int? IdentifierFromZarplataRu { get; set; }

        [JsonProperty("identifierFromAvitoRu")]
        public int? IdentifierFromAvitoRu { get; set; }

        [JsonProperty("vacancyInformation")]
        public VacancyInformation VacancyInformation { get; set; }

        [JsonProperty("professionalArea")]
        public ProfessionalArea ProfessionalArea { get; set; }
        
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

        [JsonProperty("agePreference")]
        public AgePreference AgePreference { get; set; }
        
        [JsonProperty("vacancyType")]
        public VacancyType VacancyType { get; set; }
        
        [JsonProperty("vacancyVisibilityType")]
        public VacancyVisibilityType VacancyVisibilityType { get; set; }
        
        [JsonProperty("vacancySalary")]
        public VacancySalary VacancySalary { get; set; }

        [JsonProperty("profession")]
        public Profession Profession { get; set; }

        [JsonProperty("paidPeriod")]
        public PaidPeriod PayPeriod { get; set; }

        [JsonProperty("payoutFrequency")]
        public PayoutFrequency PayoutFrequency { get; set; }

        [JsonProperty("vacancyContact")]
        public VacancyContact VacancyContact { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }

        [JsonProperty("placeOfWork")]
        public PlaceOfWork PlaceOfWork { get; set; }

        [JsonProperty("workingDays")]
        public WorkingDays WorkingDays { get; set; }

        [JsonProperty("workingShift")]
        public WorkingShift WorkingShift { get; set; }
        
        [JsonProperty("workingTimeIntervals")]
        public WorkingTimeIntervals WorkingTimeIntervals { get; set; }
        
        [JsonProperty("workingTimeModes")]
        public WorkingTimeModes WorkingTimeModes { get; set; }

        [JsonProperty("vacancyKeySkills")]
        public ICollection<VacancyKeySkill> VacancyKeySkills { get; set; }

        [JsonProperty("vacancySpecializations")]
        public ICollection<VacancySpecialization> VacancySpecializations { get; set; }
        
        [JsonProperty("vacancyDriverLicenseType")]
        public ICollection<VacancyDriverLicenseType> VacancyDriverLicenseTypes { get; set; }
    }
}