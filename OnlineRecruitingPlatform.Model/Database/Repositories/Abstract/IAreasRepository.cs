using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IAreasRepository
    {
        bool ContainsArea(Guid regionId, string name);

        bool SaveArea(Area entity);

        Area GetArea(int identifierFromHeadHunter, bool track = false);

        Area GetArea(Guid id, bool track = false);

        Area GetArea(Guid regionId, string name, bool track = false);

        IQueryable<Area> GetAreas(bool track = false);

        void DeleteArea(Guid id);
    }
}
