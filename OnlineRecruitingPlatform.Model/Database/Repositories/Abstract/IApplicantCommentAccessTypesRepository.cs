using System;
using System.Linq;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IApplicantCommentAccessTypesRepository
    {
        bool ContainsApplicantCommentAccessType(string name);

        bool SaveApplicantCommentAccessType(ApplicantCommentAccessType entity);

        ApplicantCommentAccessType GetApplicantCommentAccessType(Guid id, bool track = false);

        ApplicantCommentAccessType GetApplicantCommentAccessType(string name, bool track = false);

        IQueryable<ApplicantCommentAccessType> GetApplicantCommentAccessTypes();

        void DeleteApplicantCommentAccessType(Guid id);
    }
}
