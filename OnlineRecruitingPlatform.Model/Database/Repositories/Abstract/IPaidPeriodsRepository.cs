using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IPaidPeriodsRepository
    {
        bool ContainsPaidPeriod(string name);

        bool SavePaidPeriod(PaidPeriod entity);

        PaidPeriod GetPaidPeriod(Guid id, bool track = false);

        PaidPeriod GetPaidPeriod(string name, bool track = false);

        IQueryable<PaidPeriod> GetPaidPeriods(bool track = false);

        void DeletePaidPeriod(Guid id);
    }
}
