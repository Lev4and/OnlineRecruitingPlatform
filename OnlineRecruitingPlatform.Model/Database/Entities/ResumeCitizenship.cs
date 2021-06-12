using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeCitizenship
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid CountryId { get; set; }
        
        public Resume Resume { get; set; }
        
        public Country Country { get; set; }
    }
}