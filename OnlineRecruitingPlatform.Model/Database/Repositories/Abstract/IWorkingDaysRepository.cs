using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IWorkingDaysRepository
    {
        bool ContainsWorkingDays(string name);

        bool SaveWorkingDays(WorkingDays entity);

        WorkingDays GetWorkingDays(Guid id, bool track = false);

        WorkingDays GetWorkingDays(string name, bool track = false);

        WorkingDays GetWorkingDaysByIdentifierFromHeadHunter(string id, bool track = false);

        IQueryable<WorkingDays> GetWorkingDays(bool track = false);

        void DeleteWorkingDays(Guid id);
    }
}