using System.Collections.Generic;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ProfessionalArea
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Specialization> Specializations { get; set; }
    }
}
