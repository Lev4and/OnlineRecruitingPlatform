using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeLanguage
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid LanguageId { get; set; }
        
        public Guid LanguageLevelId { get; set; }
        
        public Resume Resume { get; set; }
        
        public Language Language { get; set; }
        
        public LanguageLevel LanguageLevel { get; set; }
    }
}