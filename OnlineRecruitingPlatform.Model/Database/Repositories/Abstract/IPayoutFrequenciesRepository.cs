using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IPayoutFrequenciesRepository
    {
        bool ContainsPayoutFrequency(string name);

        bool SavePayoutFrequency(PayoutFrequency entity);

        PayoutFrequency GetPayoutFrequency(Guid id, bool track = false);

        PayoutFrequency GetPayoutFrequency(string name, bool track = false);

        IQueryable<PayoutFrequency> GetPayoutFrequencies(bool track = false);

        void DeletePayoutFrequency(Guid id);
    }
}
