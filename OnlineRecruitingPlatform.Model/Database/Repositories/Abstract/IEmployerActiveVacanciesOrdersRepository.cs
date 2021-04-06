using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IEmployerActiveVacanciesOrdersRepository
    {
        bool ContainsEmployerActiveVacanciesOrder(string name);

        bool SaveEmployerActiveVacanciesOrder(EmployerActiveVacanciesOrder entity);

        EmployerActiveVacanciesOrder GetEmployerActiveVacanciesOrder(Guid id, bool track = false);

        EmployerActiveVacanciesOrder GetEmployerActiveVacanciesOrder(string name, bool track = false);

        IQueryable<EmployerActiveVacanciesOrder> GetEmployerActiveVacanciesOrders();

        void DeleteEmployerActiveVacanciesOrder(Guid id);
    }
}
