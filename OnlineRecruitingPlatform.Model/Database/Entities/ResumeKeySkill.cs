using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeKeySkill
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid SkillId { get; set; }
        
        public Resume Resume { get; set; }
        
        public Skill Skill { get; set; }
    }
}