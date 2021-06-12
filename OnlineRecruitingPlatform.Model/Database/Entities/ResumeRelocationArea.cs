using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeRelocationArea
    {
        public Guid Id { get; set; }
        
        public Guid ResumeRelocationId { get; set; }
        
        public Guid AreaId { get; set; }
        
        public Area Area { get; set; }
        
        public ResumeRelocation ResumeRelocation { get; set; }
    }
}