using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class Currency
    {
        public Guid Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Abbreviation { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
