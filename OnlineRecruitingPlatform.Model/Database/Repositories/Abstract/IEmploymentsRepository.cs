using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IEmploymentsRepository
    {
        bool ContainsEmployment(string name);

        bool SaveEmployment(Employment entity);

        Employment GetEmployment(Guid id, bool track = false);

        Employment GetEmployment(string name, bool track = false);

        IQueryable<Employment> GetEmployments();

        void DeleteEmployment(Guid id);
    }
}
