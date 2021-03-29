using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class ApplicantNegotiationStatusesDirectory
    {
        [JsonProperty("applicant_negotiation_status")]
        public ApplicantNegotiationStatus[] ApplicantNegotiationStatuses { get; set; }
    }
}
