using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class ApplicantCommentsOrdersDirectory
    {
        [JsonProperty("applicant_comments_order")]
        public ApplicantCommentsOrder[] ApplicantCommentsOrders { get; set; }
    }

    public class ApplicantCommentsOrdersDirectory<T> where T : ApplicantCommentsOrder
    {
        [JsonProperty("applicant_comments_order")]
        public T[] ApplicantCommentsOrders { get; set; }
    }
}
