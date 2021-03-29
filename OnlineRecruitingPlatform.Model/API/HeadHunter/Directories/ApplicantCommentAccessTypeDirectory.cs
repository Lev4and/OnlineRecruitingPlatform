﻿using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class ApplicantCommentAccessTypeDirectory
    {
        [JsonProperty("applicant_comment_access_type")]
        public ApplicantCommentAccessType[] ApplicantCommentAccessTypes { get; set; }
    }
}
