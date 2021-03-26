using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IApplicantCommentAccessTypesRepository
    {
        bool ContainsApplicantCommentAccessType(string name);

        bool SaveApplicantCommentAccessType(ApplicantCommentAccessType entity);

        ApplicantCommentAccessType GetApplicantCommentAccessType(Guid id);

        ApplicantCommentAccessType GetApplicantCommentAccessType(string name);

        IQueryable<ApplicantCommentAccessType> GetApplicantCommentAccessTypes();

        void DeleteApplicantCommentAccessType(Guid id);
    }
}
