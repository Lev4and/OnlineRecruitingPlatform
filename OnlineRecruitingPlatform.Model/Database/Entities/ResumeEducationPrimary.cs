using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeEducationPrimary
    {
        public Guid Id { get; set; }
        
        public Guid ResumeEducationId { get; set; }
        
        public Guid UniversityFacultyId { get; set; }
        
        public string Specialty { get; set; }
        
        public int Year { get; set; }
        
        public ResumeEducation ResumeEducation { get; set; }
        
        public UniversityFaculty UniversityFaculty { get; set; }
    }
}