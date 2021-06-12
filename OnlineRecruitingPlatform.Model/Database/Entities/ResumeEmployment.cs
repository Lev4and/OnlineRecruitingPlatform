using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeEmployment
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid EmploymentId { get; set; }
        
        public Resume Resume { get; set; }
        
        public Employment Employment { get; set; }
    }
}