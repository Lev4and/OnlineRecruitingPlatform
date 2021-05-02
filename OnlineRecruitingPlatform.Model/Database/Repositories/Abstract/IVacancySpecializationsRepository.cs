using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancySpecializationsRepository
    {
        bool ContainsVacancySpecialization(Guid vacancyId, Guid specializationId);

        bool SaveVacancySpecialization(VacancySpecialization entity);

        VacancySpecialization GetVacancySpecialization(Guid id, bool track = false);

        VacancySpecialization GetVacancySpecialization(Guid vacancyId, Guid specializationId, bool track = false);

        IQueryable<VacancySpecialization> GetVacancySpecializations(bool track = false);

        void DeleteVacancySpecialization(Guid id);
    }
}