using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;
using System;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Vacancies
{
    public class VacancyIV
    {
        [JsonProperty("accept_temporary")]
        public bool? AcceptTemporary { get; set; }

        [JsonProperty("has_test")]
        public bool? HasTest { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("accept_handicapped")]
        public bool AcceptHandicapped { get; set; }

        [JsonProperty("accept_kids")]
        public bool AcceptKids { get; set; }

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("alternate_url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("branded_description")]
        public string BrandedDescription { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("area")]
        public AreaIV Area { get; set; }

        [JsonProperty("employer")]
        public CompanyIV Company { get; set; }

        [JsonProperty("address")]
        public AddressIV Address { get; set; }

        [JsonProperty("schedule")]
        public ScheduleIV Schedule { get; set; }

        [JsonProperty("experience")]
        public ExperienceIV Experience { get; set; }

        [JsonProperty("employment")]
        public EmploymentIV Employment { get; set; }

        [JsonProperty("type")]
        public VacancyTypeIV VacancyType { get; set; }

        [JsonProperty("salary")]
        public VacancySalaryIV VacancySalary { get; set; }

        [JsonProperty("contacts")]
        public VacancyContactIV VacancyContact { get; set; }

        [JsonProperty("billing_type")]
        public VacancyBillingTypeIV VacancyBillingType { get; set; }

        [JsonProperty("key_skills")]
        public SkillIV2[] VacancyKeySkills { get; set; }

        [JsonProperty("working_days")]
        public WorkingDaysIV[] WorkingDays { get; set; }

        [JsonProperty("working_time_modes")]
        public WorkingTimeModesIV[] WorkingTimeModes { get; set; }

        [JsonProperty("specialization")]
        public SpecializationIV[] VacancySpecializations { get; set; }

        [JsonProperty("working_time_intervals")]
        public WorkingTimeIntervalsIV[] WorkingTimeIntervals { get; set; }

        [JsonProperty("driver_license_types")]
        public DriverLicenseTypeIV[] VacancyDriverLicenseTypes { get; set; }

    }
}
