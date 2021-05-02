using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IProfessionsRepository
    {
        bool ContainsProfession(string code, string name);

        bool SaveProfession(Profession entity);

        Profession GetProfession(Guid id, bool track = false);

        Profession GetProfession(string code, string name, bool track = false);

        IQueryable<Profession> GetProfessions(bool track = false);

        void DeleteProfession(Guid id);
    }
}