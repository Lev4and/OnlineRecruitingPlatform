using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IApplicantCommentsOrdersRepository
    {
        bool ContainsApplicantCommentsOrder(string name);

        bool SaveApplicantCommentsOrder(ApplicantCommentsOrder entity);

        ApplicantCommentsOrder GetApplicantCommentsOrder(Guid id, bool track = false);

        ApplicantCommentsOrder GetApplicantCommentsOrder(string name, bool track = false);

        IQueryable<ApplicantCommentsOrder> GetApplicantCommentsOrders();

        void DeleteApplicantCommentsOrder(Guid id);
    }
}
