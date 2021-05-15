using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IRegionsRepository
    {
        bool ContainsRegion(Guid countryId, string name);

        bool SaveRegion(Region entity);

        Region GetRegion(Guid id, bool track = false);

        Region GetRegion(Guid countryId, string name, bool track = false);

        Region GetRegionByIdentifierFromHeadHunter(int id, bool track = false);

        IQueryable<Region> GetRegions(bool track = false);

        void DeleteRegion(Guid id);
    }
}
