using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IGendersRepository
    {
        bool ContainsGender(string name);

        bool SaveGender(Gender entity);

        Gender GetGender(Guid id, bool track = false);

        Gender GetGender(string name, bool track = false);

        IQueryable<Gender> GetGenders();

        void DeleteGender(Guid id);
    }
}
