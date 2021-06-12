using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeSkill
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        [Required]
        public string Skills { get; set; }
        
        public Resume Resume { get; set; }
    }
}