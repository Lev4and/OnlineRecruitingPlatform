using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ISpecializationsRepository
    {
        bool ContainsSpecialization(string code);

        bool SaveSpecialization(Specialization entity);

        Specialization GetSpecialization(Guid id, bool track = false);

        Specialization GetSpecialization(string code, bool track = false);

        IQueryable<Specialization> GetSpecializations(bool track = false);

        void DeleteSpecialization(Guid id);
    }
}