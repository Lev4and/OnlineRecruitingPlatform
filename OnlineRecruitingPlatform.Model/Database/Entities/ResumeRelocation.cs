using System;
using System.Collections.Generic;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeRelocation
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid RelocationTypeId { get; set; }
        
        public Resume Resume { get; set; }
        
        public RelocationType RelocationType { get; set; }
        
        public ICollection<ResumeRelocationArea> ResumeRelocationAreas { get; set; }
    }
}