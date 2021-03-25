namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class SubIndustry
    {
        public int Id { get; set; }

        public int IndustryId { get; set; }

        public string Name { get; set; }

        public Industry Industry { get; set; }
    }
}
