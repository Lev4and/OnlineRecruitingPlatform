using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeSalary
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid CurrencyId { get; set; }
        
        public int Amount { get; set; }
        
        public Resume Resume { get; set; }
        
        public Currency Currency { get; set; }
    }
}