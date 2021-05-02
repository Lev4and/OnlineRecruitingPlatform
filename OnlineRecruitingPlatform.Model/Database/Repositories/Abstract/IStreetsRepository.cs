using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IStreetsRepository
    {
        bool ContainsStreet(Guid areaId, string name);

        bool SaveStreet(Street entity);

        Street GetStreet(Guid id, bool track = false);

        Street GetStreet(Guid areaId, string name, bool track = false);

        IQueryable<Street> GetStreets(bool track = false);

        void DeleteStreet(Guid id);
    }
}