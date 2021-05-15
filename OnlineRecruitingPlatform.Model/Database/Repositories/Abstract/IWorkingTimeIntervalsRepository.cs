using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IWorkingTimeIntervalsRepository
    {
        bool ContainsWorkingTimeIntervals(string name);

        bool SaveWorkingTimeIntervals(WorkingTimeIntervals entity);

        WorkingTimeIntervals GetWorkingTimeIntervals(Guid id, bool track = false);

        WorkingTimeIntervals GetWorkingTimeIntervals(string name, bool track = false);

        WorkingTimeIntervals GetWorkingTimeIntervalsByIdentifierFromHeadHunter(string id, bool track = false);

        IQueryable<WorkingTimeIntervals> GetWorkingTimeIntervals(bool track = false);

        void DeleteWorkingTimeIntervals(Guid id);
    }
}