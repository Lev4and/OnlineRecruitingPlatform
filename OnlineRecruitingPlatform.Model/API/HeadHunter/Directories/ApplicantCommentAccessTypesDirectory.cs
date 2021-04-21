using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class ApplicantCommentAccessTypesDirectory
    {
        [JsonProperty("applicant_comment_access_type")]
        public ApplicantCommentAccessType[] ApplicantCommentAccessTypes { get; set; }
    }

    public class ApplicantCommentAccessTypesDirectory<T> where T : ApplicantCommentAccessType
    {
        [JsonProperty("applicant_comment_access_type")]
        public T[] ApplicantCommentAccessTypes { get; set; }
    }
}
