using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IIndustriesRepository
    {
        bool ContainsIndustry(string name);

        bool SaveIndustry(Industry entity);

        Industry GetIndustry(Guid id, bool track = false);

        Industry GetIndustry(string name, bool track = false);

        IQueryable<Industry> GetIndustries();

        void DeleteIndustry(Guid id);
    }
}
