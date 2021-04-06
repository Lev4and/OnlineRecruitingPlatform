using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IEmployerArchivedVacanciesOrdersRepository
    {
        bool ContainsEmployerArchivedVacanciesOrder(string name);

        bool SaveEmployerArchivedVacanciesOrder(EmployerArchivedVacanciesOrder entity);

        EmployerArchivedVacanciesOrder GetEmployerArchivedVacanciesOrder(Guid id, bool track = false);

        EmployerArchivedVacanciesOrder GetEmployerArchivedVacanciesOrder(string name, bool track = false);

        IQueryable<EmployerArchivedVacanciesOrder> GetEmployerArchivedVacanciesOrders();

        void DeleteEmployerArchivedVacanciesOrder(Guid id);
    }
}
