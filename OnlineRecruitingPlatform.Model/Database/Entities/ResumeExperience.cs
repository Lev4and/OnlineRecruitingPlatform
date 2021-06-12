using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeExperience
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid? CompanyId { get; set; }
        
        public Guid? AreaId { get; set; }
        
        public string Position { get; set; }
        
        public string Description { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public Area Area { get; set; }
        
        public Resume Resume { get; set; }
        
        public Company Company { get; set; }
    }
}