using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;

namespace OnlineRecruitingPlatform.Model.Database
{
    public class DataManager
    {
        public IAddressesRepository Addresses { get; private set; }
        
        public IApplicantCommentAccessTypesRepository ApplicantCommentAccessTypes { get; private set; }

        public IApplicantCommentsOrdersRepository ApplicantCommentsOrders { get; private set; }

        public IApplicantNegotiationStatusesRepository ApplicantNegotiationStatuses { get; private set; }

        public IAreasRepository Areas { get; private set; }
        
        public IBuildingsRepository Buildings { get; private set; }

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

        public ICurrencyQuotesRepository CurrencyQuotes { get; private set; }

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
        
        public IProfessionalAreasRepository ProfessionalAreas { get; private set; }
        
        public IProfessionsRepository Professions { get; private set; }

        public IRegionsRepository Regions { get; private set; }

        public IRelationsRepository Relations { get; private set; }
        
        public ISchedulesRepository Schedules { get; private set; }

        public ISkillsRepository Skills { get; private set; }
        
        public IStreetsRepository Streets { get; private set; }

        public ISubIndustriesRepository SubIndustries { get; private set; }

        public IIdentityRolesRepository Roles { get; private set; }
        
        public IVacanciesRepository Vacancies { get; private set; }
        
        public IVacancyBillingTypesRepository VacancyBillingTypes { get; private set; }
        
        public IVacancyContactsRepository VacancyContacts { get; private set; }
        
        public IVacancyContactPhonesRepository VacancyContactPhones { get; private set; }
        
        public IVacancyDriverLicenseTypesRepository VacancyDriverLicenseTypes { get; private set; }
        
        public IVacancyInformationRepository VacancyInformation { get; private set; }
        
        public IVacancyKeySkillsRepository VacancyKeySkills { get; private set; }
        
        public IVacancyRelationsRepository VacancyRelations { get; private set; }
        
        public IVacancySalariesRepository VacancySalaries { get; private set; }
        
        public IVacancySpecializationsRepository VacancySpecializations { get; private set; }
        
        public IVacancyTypesRepository VacancyTypes { get; private set; }
        
        public IWorkingDaysRepository WorkingDays { get; private set; }
        
        public IWorkingTimeIntervalsRepository WorkingTimeIntervals { get; private set; }
        
        public IWorkingTimeModesRepository WorkingTimeModes { get; private set; }

        public DataManager(IAddressesRepository addresses, IApplicantCommentAccessTypesRepository applicantCommentAccessTypes, IApplicantCommentsOrdersRepository applicantCommentsOrders, IApplicantNegotiationStatusesRepository applicantNegotiationStatuses, IAreasRepository areas, IBuildingsRepository buildings, IBusinessTripReadinessTypesRepository businessTripReadinessTypes, ICompaniesRepository companies, ICompanyInformationRepository companyInformation, ICompanyInsiderInterviewsRepository companyInsiderInterviews, ICompanyLocationsRepository companyLocations, ICompanyLogosRepository companyLogos, ICompanyRelationsRepository companyRelations, ICompanySubIndustriesRepository companySubIndustries, ICountiesRepository counties, ICurrenciesRepository currencies, ICurrencyQuotesRepository currencyQuotes, IDriverLicenseTypesRepository driverLicenseTypes, IEducationLevelsRepository educationLevels, IEmployerActiveVacanciesOrdersRepository employerActiveVacanciesOrders, IEmployerArchivedVacanciesOrdersRepository employerArchivedVacanciesOrders, IEmployerRelationsRepository employerRelations, IEmployerTypesRepository employerTypes, IEmploymentsRepository employments, IExperiencesRepository experiences, IGendersRepository genders, IIndustriesRepository industries, ILanguagesRepository languages, ILanguageLevelsRepository languageLevels, IProfessionalAreasRepository professionalAreas, IProfessionsRepository professions, IRegionsRepository regions, IRelationsRepository relations, ISchedulesRepository schedules, ISkillsRepository skills, IStreetsRepository streets, ISubIndustriesRepository subIndustries, IIdentityRolesRepository roles, IVacanciesRepository vacancies, IVacancyBillingTypesRepository vacancyBillingTypes, IVacancyContactsRepository vacancyContacts, IVacancyContactPhonesRepository vacancyContactPhones, IVacancyDriverLicenseTypesRepository vacancyDriverLicenseTypes, IVacancyInformationRepository vacancyInformation, IVacancyKeySkillsRepository vacancyKeySkills, IVacancyRelationsRepository vacancyRelations, IVacancySalariesRepository vacancySalaries, IVacancySpecializationsRepository vacancySpecializations, IVacancyTypesRepository vacancyTypes, IWorkingDaysRepository workingDays, IWorkingTimeIntervalsRepository workingTimeIntervals, IWorkingTimeModesRepository workingTimeModes)
        {
            Addresses = addresses;
            ApplicantCommentAccessTypes = applicantCommentAccessTypes;
            ApplicantCommentsOrders = applicantCommentsOrders;
            ApplicantNegotiationStatuses = applicantNegotiationStatuses;
            Areas = areas;
            Buildings = buildings;
            BusinessTripReadinessTypes = businessTripReadinessTypes;
            Companies = companies;
            CompanyInformation = companyInformation;
            CompanyInsiderInterviews = companyInsiderInterviews;
            CompanyLocations = companyLocations;
            CompanyLogos = companyLogos;
            CompanyRelations = companyRelations;
            CompanySubIndustries = companySubIndustries;
            Currencies = currencies;
            CurrencyQuotes = currencyQuotes;
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
            ProfessionalAreas = professionalAreas;
            Professions = professions;
            Regions = regions;
            Relations = relations;
            Schedules = schedules;
            Skills = skills;
            Streets = streets;
            SubIndustries = subIndustries;
            Roles = roles;
            Vacancies = vacancies;
            VacancyBillingTypes = vacancyBillingTypes;
            VacancyContacts = vacancyContacts;
            VacancyContactPhones = vacancyContactPhones;
            VacancyDriverLicenseTypes = vacancyDriverLicenseTypes;
            VacancyInformation = vacancyInformation;
            VacancyKeySkills = vacancyKeySkills;
            VacancyRelations = vacancyRelations;
            VacancySalaries = vacancySalaries;
            VacancySpecializations = vacancySpecializations;
            VacancyTypes = vacancyTypes;
            WorkingDays = workingDays;
            WorkingTimeIntervals = workingTimeIntervals;
            WorkingTimeModes = workingTimeModes;
        }
    }
}
