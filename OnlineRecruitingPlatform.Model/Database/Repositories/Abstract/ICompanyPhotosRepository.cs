using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface ICompanyPhotosRepository
    {
        bool ContainsCompanyPhoto(Guid companyId, string photo);

        bool SaveCompanyPhoto(CompanyPhoto entity);

        CompanyPhoto GetCompanyPhoto(Guid id, bool track = false);

        CompanyPhoto GetCompanyPhoto(Guid companyId, string photo, bool track = false);

        IQueryable<CompanyPhoto> GetCompanyPhotos(bool track = false);

        void DeleteCompanyPhoto(Guid id);
    }
}
