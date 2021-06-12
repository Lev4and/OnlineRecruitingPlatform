using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class ResumeCertificate
    {
        public Guid Id { get; set; }
        
        public Guid ResumeId { get; set; }
        
        public Guid CertificateTypeId { get; set; }
        
        public string Url { get; set; }
        
        public string Owner { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        public DateTime AchievedAt { get; set; }
        
        public Resume Resume { get; set; }
        
        public CertificateType CertificateType { get; set; }
    }
}