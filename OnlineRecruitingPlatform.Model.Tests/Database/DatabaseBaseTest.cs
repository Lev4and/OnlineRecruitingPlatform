using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework;

namespace OnlineRecruitingPlatform.Model.Tests.Database
{
    public class DatabaseBaseTest
    {
        private readonly OnlineRecruitingPlatformDbContext _context;
        private protected readonly DataManager _dataManager;

        public DatabaseBaseTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<OnlineRecruitingPlatformDbContext>();
            var options = optionsBuilder.UseSqlServer(@"Server=DESKTOP-9CDGA5B;Database=OnlineRecruitingPlatform;User ID=sa;Password=sa;Trusted_Connection=True;").Options;

            _context = new OnlineRecruitingPlatformDbContext(options);
            _dataManager = new DataManager(
                new EFAddressesRepository(_context), 
                new EFApplicantCommentAccessTypesRepository(_context),
                new EFApplicantCommentsOrdersRepository(_context),
                new EFApplicantNegotiationStatusesRepository(_context),
                new EFAreasRepository(_context),
                new EFBuildingsRepository(_context), 
                new EFBusinessTripReadinessTypesRepository(_context), 
                new EFCompaniesRepository(_context),
                new EFCompanyInformationRepository(_context),
                new EFCompanyInsiderInterviewsRepository(_context),
                new EFCompanyLocationsRepository(_context),
                new EFCompanyLogosRepository(_context),
                new EFCompanyRelationsRepository(_context),
                new EFCompanySubIndustriesRepository(_context), 
                new EFCountiesRepository(_context),
                new EFCurrenciesRepository(_context),
                new EFCurrencyQuotesRepository(_context),
                new EFDriverLicenseTypesRepository(_context),
                new EFEducationLevelsRepository(_context),
                new EFEmployerActiveVacanciesOrdersRepository(_context),
                new EFEmployerArchivedVacanciesOrdersRepository(_context),
                new EFEmployerRelationsRepository(_context),
                new EFEmployerTypesRepository(_context),
                new EFEmploymentsRepository(_context),
                new EFExperiencesRepository(_context),
                new EFGendersRepository(_context),
                new EFIndustriesRepository(_context),
                new EFLanguagesRepository(_context),
                new EFLanguageLevelsRepository(_context),
                new EFProfessionalAreasRepository(_context), 
                new EFProfessionsRepository(_context), 
                new EFRegionsRepository(_context),
                new EFRelationsRepository(_context), 
                new EFSchedulesRepository(_context), 
                new EFSkillsRepository(_context),
                new EFSpecializationsRepository(_context), 
                new EFStreetsRepository(_context), 
                new EFSubIndustriesRepository(_context),
                new EFIdentityRolesRepository(_context), 
                new EFVacanciesRepository(_context),
                new EFVacancyBillingTypesRepository(_context), 
                new EFVacancyContactsRepository(_context),
                new EFVacancyContactPhonesRepository(_context),
                new EFVacancyDriverLicenseTypesRepository(_context),
                new EFVacancyInformationRepository(_context),
                new EFVacancyKeySkillsRepository(_context),
                new EFVacancyRelationsRepository(_context),
                new EFVacancySalariesRepository(_context),
                new EFVacancySpecializationsRepository(_context),
                new EFVacancyTypesRepository(_context),
                new EFWorkingDaysRepository(_context),
                new EFWorkingTimeIntervalsRepository(_context),
                new EFWorkingTimeModesRepository(_context));
        }
    }
}
