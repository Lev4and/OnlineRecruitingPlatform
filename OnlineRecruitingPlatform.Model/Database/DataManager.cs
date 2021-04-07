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

        public IEmployerActiveVacanciesOrdersRepository EmployerActiveVacanciesOrders { get; private set; }

        public IEmployerArchivedVacanciesOrdersRepository EmployerArchivedVacanciesOrders { get; private set; }

        public IEmployerRelationsRepository EmployerRelations { get; private set; }

        public IEmployerTypesRepository EmployerTypes { get; private set; }

        public IEmploymentsRepository Employments { get; private set; }

        public IExperiencesRepository Experiences { get; private set; }

        public IGendersRepository Genders { get; private set; }

        public ILanguagesRepository Languages { get; private set; }

        public IIdentityRolesRepository Roles { get; private set; }

        public DataManager(IApplicantCommentAccessTypesRepository applicantCommentAccessTypes, IApplicantCommentsOrdersRepository applicantCommentsOrders, IApplicantNegotiationStatusesRepository applicantNegotiationStatuses, IBusinessTripReadinessTypesRepository businessTripReadinessTypes, ICurrenciesRepository currencies, IDriverLicenseTypesRepository driverLicenseTypes, IEducationLevelsRepository educationLevels, IEmployerActiveVacanciesOrdersRepository employerActiveVacanciesOrders, IEmployerArchivedVacanciesOrdersRepository employerArchivedVacanciesOrders, IEmployerRelationsRepository employerRelations, IEmployerTypesRepository employerTypes, IEmploymentsRepository employments, IExperiencesRepository experiences, IGendersRepository genders, ILanguagesRepository languages, IIdentityRolesRepository roles)
        {
            ApplicantCommentAccessTypes = applicantCommentAccessTypes;
            ApplicantCommentsOrders = applicantCommentsOrders;
            ApplicantNegotiationStatuses = applicantNegotiationStatuses;
            BusinessTripReadinessTypes = businessTripReadinessTypes;
            Currencies = currencies;
            DriverLicenseTypes = driverLicenseTypes;
            EducationLevels = educationLevels;
            EmployerActiveVacanciesOrders = employerActiveVacanciesOrders;
            EmployerArchivedVacanciesOrders = employerArchivedVacanciesOrders;
            EmployerRelations = employerRelations;
            EmployerTypes = employerTypes;
            Employments = employments;
            Experiences = experiences;
            Genders = genders;
            Languages = languages;
            Roles = roles;
        }
    }
}
