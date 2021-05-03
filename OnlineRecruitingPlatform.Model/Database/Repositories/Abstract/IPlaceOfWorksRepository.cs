using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IPlaceOfWorksRepository
    {
        bool ContainsPlaceOfWork(string name);

        bool SavePlaceOfWork(PlaceOfWork entity);

        PlaceOfWork GetPlaceOfWork(Guid id, bool track = false);

        PlaceOfWork GetPlaceOfWork(string name, bool track = false);

        IQueryable<PlaceOfWork> GetPlaceOfWorks(bool track = false);

        void DeletePlaceOfWork(Guid id);
    }
}
