using System.Collections.Generic;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Industry
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<SubIndustry> SubIndustries { get; set; }
    }
}
