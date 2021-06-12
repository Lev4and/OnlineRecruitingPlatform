using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeSpecialization
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid SpecializationId { get; set; }

        public Resume Resume { get; set; }
        
        public Specialization Specialization { get; set; }
    }
}