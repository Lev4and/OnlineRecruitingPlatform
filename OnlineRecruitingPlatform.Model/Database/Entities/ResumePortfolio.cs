using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumePortfolio : IImportedFromHeadHunter<string>
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public string Small { get; set; }
        
        public string Medium { get; set; }
        
        public string Description { get; set; }
        
        public string IdentifierFromHeadHunter { get; set; }
        
        public Resume Resume { get; set; }
    }
}