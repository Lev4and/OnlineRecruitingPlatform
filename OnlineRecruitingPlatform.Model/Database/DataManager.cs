using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database
{
    public class DataManager
    {
        public IApplicantCommentAccessTypesRepository ApplicantCommentAccessTypes;

        public IApplicantCommentsOrdersRepository ApplicantCommentsOrders;

        public IApplicantNegotiationStatusesRepository ApplicantNegotiationStatuses;

        public IBusinessTripReadinessTypesRepository BusinessTripReadinessTypes;

        public IIdentityRolesRepository Roles { get; set; }

        public DataManager(IApplicantCommentAccessTypesRepository applicantCommentAccessTypes, IApplicantCommentsOrdersRepository applicantCommentsOrders, IApplicantNegotiationStatusesRepository applicantNegotiationStatuses, IBusinessTripReadinessTypesRepository businessTripReadinessTypes, IIdentityRolesRepository roles)
        {
            ApplicantCommentAccessTypes = applicantCommentAccessTypes;
            ApplicantCommentsOrders = applicantCommentsOrders;
            ApplicantNegotiationStatuses = applicantNegotiationStatuses;
            BusinessTripReadinessTypes = businessTripReadinessTypes;
            Roles = roles;
        }
    }
}
