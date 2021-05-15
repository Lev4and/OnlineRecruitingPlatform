using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IWorkingTimeModesRepository
    {
        bool ContainsWorkingTimeModes(string name);

        bool SaveWorkingTimeModes(WorkingTimeModes entity);

        WorkingTimeModes GetWorkingTimeModes(Guid id, bool track = false);

        WorkingTimeModes GetWorkingTimeModes(string name, bool track = false);

        WorkingTimeModes GetWorkingTimeModesByIdentifierFromHeadHunter(string id, bool track = false);

        IQueryable<WorkingTimeModes> GetWorkingTimeModes(bool track = false);

        void DeleteWorkingTimeModes(Guid id);
    }
}