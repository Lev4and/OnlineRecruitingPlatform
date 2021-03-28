using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IBusinessTripReadinessTypesRepository
    {
        bool ContainsBusinessTripReadiness(string name);

        bool SaveBusinessTripReadiness(BusinessTripReadiness entity);

        BusinessTripReadiness GetBusinessTripReadiness(Guid id, bool track = false);

        BusinessTripReadiness GetBusinessTripReadiness(string name, bool track = false);

        IQueryable<BusinessTripReadiness> GetBusinessTripReadinessTypes();

        void DeleteBusinessTripReadiness(Guid id);
    }
}
