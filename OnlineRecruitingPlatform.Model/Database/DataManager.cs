using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database
{
    public class DataManager
    {
        public IApplicantCommentAccessTypesRepository ApplicantCommentAccessTypes { get; private set; }

        public IApplicantCommentsOrdersRepository ApplicantCommentsOrders { get; private set; }

        public IApplicantNegotiationStatusesRepository ApplicantNegotiationStatuses { get; private set; }

        public IBusinessTripReadinessTypesRepository BusinessTripReadinessTypes { get; private set; }

        public ICurrenciesRepository Currencies { get; private set; }

        public IDriverLicenseTypesRepository DriverLicenseTypes { get; private set; }

        public IEducationLevelsRepository EducationLevels { get; private set; }

        public IIdentityRolesRepository Roles { get; private set; }

        public DataManager(IApplicantCommentAccessTypesRepository applicantCommentAccessTypes, IApplicantCommentsOrdersRepository applicantCommentsOrders, IApplicantNegotiationStatusesRepository applicantNegotiationStatuses, IBusinessTripReadinessTypesRepository businessTripReadinessTypes, ICurrenciesRepository currencies, IDriverLicenseTypesRepository driverLicenseTypes, IEducationLevelsRepository educationLevels, IIdentityRolesRepository roles)
        {
            ApplicantCommentAccessTypes = applicantCommentAccessTypes;
            ApplicantCommentsOrders = applicantCommentsOrders;
            ApplicantNegotiationStatuses = applicantNegotiationStatuses;
            BusinessTripReadinessTypes = businessTripReadinessTypes;
            DriverLicenseTypes = driverLicenseTypes;
            EducationLevels = educationLevels;
            Currencies = currencies;
            Roles = roles;
        }
    }
}
