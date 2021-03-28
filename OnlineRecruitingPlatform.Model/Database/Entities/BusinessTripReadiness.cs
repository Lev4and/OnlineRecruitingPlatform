using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class BusinessTripReadiness
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
