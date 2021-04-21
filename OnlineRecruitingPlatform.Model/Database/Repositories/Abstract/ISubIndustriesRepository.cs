using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ISubIndustriesRepository
    {
        bool ContainsSubIndustry(string name);

        bool SaveSubIndustry(SubIndustry entity);

        SubIndustry GetSubIndustry(Guid id, bool track = false);

        SubIndustry GetSubIndustry(string name, bool track = false);

        IQueryable<SubIndustry> GetSubIndustries();

        void DeleteSubIndustry(Guid id);
    }
}
