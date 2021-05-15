using System;
using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.ZarplataRu
{
    public class VacancyIV
    {
        [JsonProperty("is_available_for_students")]
        public bool? AcceptStudent { get; set; }
        
        [JsonProperty("remote_interview")]
        public bool? RemoteInterview { get; set; }
        
        [JsonProperty("is_available_for_pensioners")]
        public bool? AcceptPensioner { get; set; }

        [JsonProperty("is_available_for_invalids")]
        public bool? AcceptHandicapped { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("salary_max")]
        public double? UpperWageLimit { get; set; }
        
        [JsonProperty("salary_max_rub")]
        public double? UpperWageLimitRubles { get; set; }

        [JsonProperty("salary_min")]
        public double? LowerWageLimit { get; set; }
        
        [JsonProperty("salary_min_rub")]
        public double? LowerWageLimitRubles { get; set; }
        
        [JsonProperty("bonus")]
        public double? Bonus { get; set; }
        
        [JsonProperty("is_salary_gross")]
        public bool Gross { get; set; }
        
        [JsonProperty("header")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("mod_date")]
        public DateTime ModifiedAt { get; set; }
        
        [JsonProperty("update_date")]
        public DateTime UpdatedAt { get; set; }
        
        [JsonProperty("company")]
        public CompanyIV Company { get; set; }

        [JsonProperty("currency")]
        public CurrencyIVZarplataRu Currency { get; set; }

        [JsonProperty("schedule")]
        public ScheduleIVZarplataRu Schedule { get; set; }

        [JsonProperty("working_type")]
        public EmploymentIVZarplataRu Employment { get; set; }
        
        [JsonProperty("experience_length")]
        public ExperienceIVZarplataRu Experience { get; set; }

        [JsonProperty("position_dictionary")]
        public ProfessionIVZarplataRu Profession { get; set; }

        [JsonProperty("contact")]
        public VacancyContactIVZarplataRu VacancyContact { get; set; }

        [JsonProperty("education")]
        public EducationLevelIVZarplataRu EducationLevel { get; set; }

        [JsonProperty("rubrics")]
        public ProfessionalAreaIVZarplataRuWithSpecializations[] ProfessionalAreas { get; set; }
    }
}