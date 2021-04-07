using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IEmployerTypesRepository
    {
        bool ContainsEmployerType(string name);

        bool SaveEmployerType(EmployerType entity);

        EmployerType GetEmployerType(Guid id, bool track = false);

        EmployerType GetEmployerType(string name, bool track = false);

        IQueryable<EmployerType> GetEmployerTypes();

        void DeleteEmployerType(Guid id);
    }
}
