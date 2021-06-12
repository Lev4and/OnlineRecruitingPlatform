using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeContactPhone
    {
        public Guid Id { get; set; }
        
        public Guid ResumeContactPhoneId { get; set; }
        
        public string CountryCode { get; set; }
        
        public string CityCode { get; set; }
        
        public string Number { get; set; }
        
        public string Formatted { get; set; }
        
        public ResumeContact ResumeContact { get; set; }
    }
}