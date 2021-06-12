using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeContact
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid PreferredContactTypeId { get; set; }
        
        public string Email { get; set; }
        
        public Resume Resume { get; set; }
        
        public ResumeContactPhone ResumeContactPhone { get; set; }
        
        public PreferredContactType PreferredContactType { get; set; }
    }
}