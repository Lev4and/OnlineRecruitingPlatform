using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeTotalExperience
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public int Months { get; set; }
        
        public Resume Resume { get; set; }
    }
}