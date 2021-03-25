namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Specialization
    {
        public int Id { get; set; }

        public int ProfessionalAreaId { get; set; }

        public string Name { get; set; }

        public ProfessionalArea ProfessionalArea { get; set; }
    }
}
