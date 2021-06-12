using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeTravelTime
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid TravelTimeId { get; set; }
        
        public Resume Resume { get; set; }
        
        public TravelTime TravelTime { get; set; }
    }
}