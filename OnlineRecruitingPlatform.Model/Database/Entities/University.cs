using System;
using System.Collections.Generic;

namespace OnlineRecruitingPlatform.Model.Database.Entities
{
    public class University
    {
        public Guid Id { get; set; }
        
        public string Synonyms { get; set; }
        
        public string Acronym { get; set; }
        
        public string Name { get; set; }
        
        public ICollection<UniversityFaculty> UniversityFaculties { get; set; }
    }
}