using OnlineRecruitingPlatform.Model.Database.Entities;
using System;
using System.Linq;

namespace OnlineRecruitingPlatform.Model.Database.Repositories.Abstract
{
    public interface IApplicantNegotiationStatusesRepository
    {
        bool ContainsApplicantNegotiationStatus(string name);

        bool SaveApplicantNegotiationStatus(ApplicantNegotiationStatus entity);

        ApplicantNegotiationStatus GetApplicantNegotiationStatus(Guid id, bool track = false);

        ApplicantNegotiationStatus GetApplicantNegotiationStatus(string name, bool track = false);

        IQueryable<ApplicantNegotiationStatus> GetApplicantNegotiationStatuses();

        void DeleteApplicantNegotiationStatus(Guid id);
    }
}
