using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class EmployerRelationsDirectory
    {
        [JsonProperty("employer_relation")]
        public EmployerRelation[] EmployerRelations { get; set; }
    }

    public class EmployerRelationsDirectory<T> where T : EmployerRelation
    {
        [JsonProperty("employer_relation")]
        public T[] EmployerRelations { get; set; }
    }
}
