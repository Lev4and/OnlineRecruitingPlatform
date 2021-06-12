using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeRecommendation
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Position { get; set; }
        
        [Required]
        public string Organization { get; set; }
        
        public Resume Resume { get; set; }
    }
}