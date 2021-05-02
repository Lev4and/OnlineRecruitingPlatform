using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IAddressesRepository
    {
        bool ContainsAddress(Guid? cityId, Guid? streetId, Guid? buildingId);

        bool SaveAddress(Address entity);

        Address GetAddress(Guid id, bool track = false);

        Address GetAddress(Guid? cityId, Guid? streetId, Guid? buildingId, bool track = false);

        IQueryable<Address> GetAddress(bool track = false);

        void DeleteAddress(Guid id);
    }
}