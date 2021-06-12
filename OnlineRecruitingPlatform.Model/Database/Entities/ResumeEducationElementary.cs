using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeEducationElementary
    {
        public Guid Id { get; set; }
        
        public Guid ResumeEducationId { get; set; }
        
        public int Year { get; set; }
        
        public string Name { get; set; }
        
        public ResumeEducation ResumeEducation { get; set; }
    }
}