using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancyContactsRepository
    {
        bool ContainsVacancyContact(Guid vacancyId);

        bool SaveVacancyContact(VacancyContact entity);

        VacancyContact GetVacancyContact(Guid vacancyId, bool track = false);

        IQueryable<VacancyContact> GetVacancyContacts(bool track = false);

        void DeleteVacancyContact(Guid id);
    }
}