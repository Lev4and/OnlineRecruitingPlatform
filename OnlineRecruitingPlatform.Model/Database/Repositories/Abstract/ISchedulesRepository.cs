using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ISchedulesRepository
    {
        bool ContainsSchedule(string name);

        bool SaveSchedule(Schedule entity);

        Schedule GetSchedule(Guid id, bool track = false);

        Schedule GetSchedule(string name, bool track = false);

        Schedule GetScheduleByIdentifierFromHeadHunter(string id, bool track = false);

        Schedule GetScheduleByIdentifierFromAvitoRu(string id, bool track = false);

        Schedule GetScheduleByIdentifierFromZarplataRu(int id, bool track = false);

        IQueryable<Schedule> GetSchedules(bool track = false);

        void DeleteSchedule(Guid id);
    }
}