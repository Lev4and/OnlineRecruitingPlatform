using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database
{
    public class DataManager
    {
        public IApplicantCommentAccessTypesRepository ApplicantCommentAccessTypes { get; private set; }

        public IApplicantCommentsOrdersRepository ApplicantCommentsOrders { get; private set; }

        public IApplicantNegotiationStatusesRepository ApplicantNegotiationStatuses { get; private set; }

        public IAreasRepository Areas { get; private set; }

        public IBusinessTripReadinessTypesRepository BusinessTripReadinessTypes { get; private set; }

        public ICompaniesRepository Companies { get; private set; }

        public ICompanyInformationRepository CompanyInformation { get; set; }

        public ICompanyInsiderInterviewsRepository CompanyInsiderInterviews { get; set; }

        public ICompanyLocationsRepository CompanyLocations { get; set; }

        public ICompanyLogosRepository CompanyLogos { get; set; }

        public ICompanyRelationsRepository CompanyRelations { get; set; }

        public ICompanySubIndustriesRepository CompanySubIndustries { get; set; }

        public ICountiesRepository Counties { get; private set; }

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

        public IIndustriesRepository Industries { get; private set; }

        public ILanguagesRepository Languages { get; private set; }

        public ILanguageLevelsRepository LanguageLevels { get; private set; }

        public IRegionsRepository Regions { get; private set; }

        public IRelationsRepository Relations { get; private set; }

        public ISkillsRepository Skills { get; private set; }

        public ISubIndustriesRepository SubIndustries { get; private set; }

        public IIdentityRolesRepository Roles { get; private set; }

        public DataManager(IApplicantCommentAccessTypesRepository applicantCommentAccessTypes, IApplicantCommentsOrdersRepository applicantCommentsOrders, IApplicantNegotiationStatusesRepository applicantNegotiationStatuses, IAreasRepository areas, IBusinessTripReadinessTypesRepository businessTripReadinessTypes, ICompaniesRepository companies, ICompanyInformationRepository companyInformation, ICompanyInsiderInterviewsRepository companyInsiderInterviews, ICompanyLocationsRepository companyLocations, ICompanyLogosRepository companyLogos, ICompanyRelationsRepository companyRelations, ICompanySubIndustriesRepository companySubIndustries, ICountiesRepository counties, ICurrenciesRepository currencies, IDriverLicenseTypesRepository driverLicenseTypes, IEducationLevelsRepository educationLevels, IEmployerActiveVacanciesOrdersRepository employerActiveVacanciesOrders, IEmployerArchivedVacanciesOrdersRepository employerArchivedVacanciesOrders, IEmployerRelationsRepository employerRelations, IEmployerTypesRepository employerTypes, IEmploymentsRepository employments, IExperiencesRepository experiences, IGendersRepository genders, IIndustriesRepository industries, ILanguagesRepository languages, ILanguageLevelsRepository languageLevels, IRegionsRepository regions, IRelationsRepository relations, ISkillsRepository skills, ISubIndustriesRepository subIndustries, IIdentityRolesRepository roles)
        {
            ApplicantCommentAccessTypes = applicantCommentAccessTypes;
            ApplicantCommentsOrders = applicantCommentsOrders;
            ApplicantNegotiationStatuses = applicantNegotiationStatuses;
            Areas = areas;
            BusinessTripReadinessTypes = businessTripReadinessTypes;
            Companies = companies;
            CompanyInformation = companyInformation;
            CompanyInsiderInterviews = companyInsiderInterviews;
            CompanyLocations = companyLocations;
            CompanyLogos = companyLogos;
            CompanyRelations = companyRelations;
            CompanySubIndustries = companySubIndustries;
            Currencies = currencies;
            Counties = counties;
            DriverLicenseTypes = driverLicenseTypes;
            EducationLevels = educationLevels;
            EmployerActiveVacanciesOrders = employerActiveVacanciesOrders;
            EmployerArchivedVacanciesOrders = employerArchivedVacanciesOrders;
            EmployerRelations = employerRelations;
            EmployerTypes = employerTypes;
            Employments = employments;
            Experiences = experiences;
            Genders = genders;
            Industries = industries;
            Languages = languages;
            LanguageLevels = languageLevels;
            Regions = regions;
            Relations = relations;
            Skills = skills;
            SubIndustries = subIndustries;
            Roles = roles;
        }
    }
}
