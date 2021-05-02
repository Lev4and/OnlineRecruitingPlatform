using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IProfessionalAreasRepository
    {
        bool ContainsProfessionalArea(string code, string name);

        bool SaveProfessionalArea(ProfessionalArea entity);

        ProfessionalArea GetProfessionalArea(Guid id, bool track = false);

        ProfessionalArea GetProfessionalArea(string code, string name, bool track = false);

        IQueryable<ProfessionalArea> GetProfessionalAreas(bool track = false);

        void DeleteProfessionalArea(Guid id);
    }
}