using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeContactsSiteType : IImportedFromHeadHunter<string>
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string IdentifierFromHeadHunter { get; set; }
        
        public ICollection<ResumeSite> ResumeSites { get; set; }
    }
}
