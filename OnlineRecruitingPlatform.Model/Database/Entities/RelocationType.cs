using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class RelocationType : IImportedFromHeadHunter<string>
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string IdentifierFromHeadHunter { get; set; }
        
        public ICollection<ResumeRelocation> ResumeRelocation { get; set; }
    }
}
