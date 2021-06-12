using System;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeDriverLicenseType
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid DriverLicenseTypeId { get; set; }
        
        public Resume Resume { get; set; }
        
        public DriverLicenseType DriverLicenseType { get; set; }
    }
}