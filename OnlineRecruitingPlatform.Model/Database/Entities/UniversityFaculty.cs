using System;
using System.Collections.Generic;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class UniversityFaculty
    {
        public Guid Id { get; set; }
        
        public Guid UniversityId { get; set; }
        
        public string Name { get; set; }
        
        public University University { get; set; }
        
        public ICollection<ResumeEducationPrimary> ResumeEducationPrimaries { get; set; }
    }
}