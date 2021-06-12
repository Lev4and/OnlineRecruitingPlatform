using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeEducationAdditional
    {
        public Guid Id { get; set; }
        
        public Guid ResumeEducationId { get; set; }
        
        public string Organization { get; set; }
        
        public string Result { get; set; }
        
        public string Name { get; set; }
        
        public int Year { get; set; }
        
        public ResumeEducation ResumeEducation { get; set; }
    }
}