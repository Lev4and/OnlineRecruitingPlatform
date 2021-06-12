using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeSite
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid ResumeContactsSiteTypeId { get; set; }
        
        public string Url { get; set; }
        
        public Resume Resume { get; set; }
        
        public ResumeContactsSiteType ResumeContactsSiteType { get; set; }
    }
}