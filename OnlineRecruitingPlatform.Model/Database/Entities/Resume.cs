using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Resume : IImportedFromHeadHunter<int?>
    {
        public Guid Id { get; set; }
        
        public Guid? GenderId { get; set; }
        
        public Guid? ResumeStatusId { get; set; }
        
        public Guid? BusinessTripReadinessId { get; set; }
        
        public bool? HasVehicle { get; set; }
        
        public string Url { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        public string LastName { get; set; }
        
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        
        public DateTime? BirthDate { get; set; }
        
        public DataType? CreatedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }

        public int? IdentifierFromHeadHunter { get; set; }
        
        public Gender Gender { get; set; }

        public ResumeSkill ResumeSkill { get; set; }
        
        public ResumePhoto ResumePhoto { get; set; }
        
        public ResumeStatus ResumeStatus { get; set; }
        
        public ResumeSalary ResumeSalary { get; set; }
        
        public ResumeEducation ResumeEducation { get; set; }

        public ResumeRelocation ResumeRelocation { get; set; }
        
        public ResumeTravelTime ResumeTravelTime { get; set; }
        
        public ResumeTotalExperience ResumeTotalExperience { get; set; }
        
        public BusinessTripReadiness BusinessTripReadiness { get; set; }
        
        public ICollection<ResumeDriverLicenseType> ResumeDriverLicenseTypes { get; set; }
        
        public ICollection<ResumeSpecialization> ResumeSpecializations { get; set; }
        
        public ICollection<ResumeRecommendation> ResumeRecommendations { get; set; }
        
        public ICollection<ResumeCertificate> ResumeCertificates { get; set; }
        
        public ICollection<ResumeCitizenship> ResumeCitizenship { get; set; }

        public ICollection<ResumeEmployment> ResumeEmployments { get; set; }
        
        public ICollection<ResumeExperience> ResumeExperiences { get; set; }
        
        public ICollection<ResumePortfolio> ResumePortfolios { get; set; }
        
        public ICollection<ResumeSchedule> ResumeSchedules { get; set; }
        
        public ICollection<ResumeLanguage> ResumeLanguages { get; set; }
        
        public ICollection<ResumeKeySkill> ResumeKeySkills { get; set; }
        
        public ICollection<ResumeContact> ResumeContacts { get; set; }
        
        public ICollection<ResumeSite> ResumeSites { get; set; }
    }
}