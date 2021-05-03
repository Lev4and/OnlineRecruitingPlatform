using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IWorkingShiftsRepository
    {
        bool ContainsWorkingShift(string name);

        bool SaveWorkingShift(WorkingShift entity);

        WorkingShift GetWorkingShift(Guid id, bool track = false);

        WorkingShift GetWorkingShift(string name, bool track = false);

        IQueryable<WorkingShift> GetWorkingShifts(bool track = false);

        void DeleteWorkingShift(Guid id);
    }
}
