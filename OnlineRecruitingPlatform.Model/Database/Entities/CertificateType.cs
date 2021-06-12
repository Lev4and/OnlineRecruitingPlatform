using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class CertificateType : IImportedFromHeadHunter<string>
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string IdentifierFromHeadHunter { get; set; }
        
        public ICollection<ResumeCertificate> ResumeCertificates { get; set; }
    }
}