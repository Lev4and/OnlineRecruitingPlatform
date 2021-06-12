using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeSchedule
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid ScheduleId { get; set; }
        
        public Resume Resume { get; set; }
        
        public Schedule Schedule { get; set; }
    }
}