using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class TravelTime : IImportedFromHeadHunter<string>
    {
        public Guid Id { get; set; }

        [Required]
        public int Name { get; set; }
        
        public string IdentifierFromHeadHunter { get; set; }
        
        public ICollection<ResumeTravelTime> ResumeTravelTimes { get; set; }
    }
}
