using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IVacancyContactPhonesRepository
    {
        bool ContainsVacancyContactPhone(Guid vacancyContactId, string countryCode, string cityCode, string number);

        bool SaveVacancyContactPhone(VacancyContactPhone entity);

        VacancyContactPhone GetVacancyContactPhone(Guid id, bool track = false);

        VacancyContactPhone GetVacancyContactPhone(Guid vacancyContactId, string countryCode, string cityCode,
            string number, bool track = false);

        IQueryable<VacancyContactPhone> GetVacancyContactPhones(bool track = false);

        void DeleteVacancyContactPhone(Guid id);
    }
}