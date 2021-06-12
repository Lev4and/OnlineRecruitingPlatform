using System;
using System.Collections.Generic;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeEducation
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid EducationLevelId { get; set; }
        
        public Resume Resume { get; set; }
        
        public EducationLevel EducationLevel { get; set; }
        
        public ICollection<ResumeEducationPrimary> ResumeEducationPrimaries { get; set; }
        
        public ICollection<ResumeEducationElementary> ResumeEducationElementary { get; set; }
        
        public ICollection<ResumeEducationAdditional> ResumeEducationAdditionally { get; set; }
        
        public ICollection<ResumeEducationAttestation> ResumeEducationAttestations { get; set; }
    }
}