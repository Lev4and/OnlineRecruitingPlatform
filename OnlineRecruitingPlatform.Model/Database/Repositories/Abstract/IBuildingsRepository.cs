using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IBuildingsRepository
    {
        bool ContainsBuilding(Guid streetId, string name);

        bool SaveBuilding(Building entity);

        Building GetBuilding(Guid id, bool track = false);

        Building GetBuilding(Guid streetId, string name, bool track = false);

        IQueryable<Building> GetBuildings(bool track = false);

        void DeleteBuildings(Guid id);
    }
}