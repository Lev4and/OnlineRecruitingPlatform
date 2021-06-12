using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Service;
using OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Directories;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());

            services.AddTransient<CurrenciesClient>();
            services.AddTransient<ApplicantCommentsOrdersClient>();
            services.AddTransient<BusinessTripReadinessTypesClient>();
            services.AddTransient<ApplicantCommentAccessTypesClient>();
            services.AddTransient<ApplicantNegotiationStatusesClient>();

            services.AddTransient<IAreasRepository, EFAreasRepository>();
            services.AddTransient<ISkillsRepository, EFSkillsRepository>();
            services.AddTransient<IRegionsRepository, EFRegionsRepository>();
            services.AddTransient<IGendersRepository, EFGendersRepository>();
            services.AddTransient<IStreetsRepository, EFStreetsRepository>();
            services.AddTransient<ICountiesRepository, EFCountiesRepository>();
            services.AddTransient<IVacanciesRepository, EFVacanciesRepository>();
            services.AddTransient<ILanguagesRepository, EFLanguagesRepository>();
            services.AddTransient<IRelationsRepository, EFRelationsRepository>();
            services.AddTransient<ICompaniesRepository, EFCompaniesRepository>();
            services.AddTransient<IAddressesRepository, EFAddressesRepository>();
            services.AddTransient<IBuildingsRepository, EFBuildingsRepository>();
            services.AddTransient<ISchedulesRepository, EFSchedulesRepository>();
            services.AddTransient<ICurrenciesRepository, EFCurrenciesRepository>();
            services.AddTransient<IIndustriesRepository, EFIndustriesRepository>();
            services.AddTransient<IWorkingDaysRepository, EFWorkingDaysRepository>();
            services.AddTransient<IEmploymentsRepository, EFEmploymentsRepository>();
            services.AddTransient<IExperiencesRepository, EFExperiencesRepository>();
            services.AddTransient<IProfessionsRepository, EFProfessionsRepository>();
            services.AddTransient<IPaidPeriodsRepository, EFPaidPeriodsRepository>();
            services.AddTransient<IPlaceOfWorksRepository, EFPlaceOfWorksRepository>();
            services.AddTransient<IVacancyTypesRepository, EFVacancyTypesRepository>();
            services.AddTransient<ICompanyLogosRepository, EFCompanyLogosRepository>();
            services.AddTransient<ICompanyPhotosRepository, EFCompanyPhotosRepository>();
            services.AddTransient<IWorkingShiftsRepository, EFWorkingShiftsRepository>();
            services.AddTransient<ISubIndustriesRepository, EFSubIndustriesRepository>();
            services.AddTransient<IEmployerTypesRepository, EFEmployerTypesRepository>();
            services.AddTransient<IIdentityRolesRepository, EFIdentityRolesRepository>();
            services.AddTransient<IAgePreferencesRepository, EFAgePreferencesRepository>();
            services.AddTransient<ILanguageLevelsRepository, EFLanguageLevelsRepository>();
            services.AddTransient<ICurrencyQuotesRepository, EFCurrencyQuotesRepository>();
            services.AddTransient<IEducationLevelsRepository, EFEducationLevelsRepository>();
            services.AddTransient<IVacancyContactsRepository, EFVacancyContactsRepository>();
            services.AddTransient<IVacancySalariesRepository, EFVacancySalariesRepository>();
            services.AddTransient<ISpecializationsRepository, EFSpecializationsRepository>();
            services.AddTransient<ICompanyContactsRepository, EFCompanyContactsRepository>();
            services.AddTransient<ICompanyLocationsRepository, EFCompanyLocationsRepository>();
            services.AddTransient<ICompanyRelationsRepository, EFCompanyRelationsRepository>();
            services.AddTransient<IVacancyKeySkillsRepository, EFVacancyKeySkillsRepository>();
            services.AddTransient<IVacancyRelationsRepository, EFVacancyRelationsRepository>();
            services.AddTransient<IWorkingTimeModesRepository, EFWorkingTimeModesRepository>();
            services.AddTransient<IPayoutFrequenciesRepository, EFPayoutFrequenciesRepository>();
            services.AddTransient<IProfessionalAreasRepository, EFProfessionalAreasRepository>();
            services.AddTransient<IEmployerRelationsRepository, EFEmployerRelationsRepository>();
            services.AddTransient<IDriverLicenseTypesRepository, EFDriverLicenseTypesRepository>();
            services.AddTransient<ICompanyInformationRepository, EFCompanyInformationRepository>();
            services.AddTransient<IVacancyInformationRepository, EFVacancyInformationRepository>();
            services.AddTransient<IVacancyBillingTypesRepository, EFVacancyBillingTypesRepository>();
            services.AddTransient<IWorkingTimeIntervalsRepository, EFWorkingTimeIntervalsRepository>();
            services.AddTransient<ICompanySubIndustriesRepository, EFCompanySubIndustriesRepository>();
            services.AddTransient<IVacancyContactPhonesRepository, EFVacancyContactPhonesRepository>();
            services.AddTransient<ICompanyContactPhonesRepository, EFCompanyContactPhonesRepository>();
            services.AddTransient<IVacancySpecializationsRepository, EFVacancySpecializationsRepository>();
            services.AddTransient<IVacancyVisibilityTypesRepository, EFVacancyVisibilityTypesRepository>();
            services.AddTransient<IApplicantCommentsOrdersRepository, EFApplicantCommentsOrdersRepository>();
            services.AddTransient<ICompanyInsiderInterviewsRepository, EFCompanyInsiderInterviewsRepository>();
            services.AddTransient<IVacancyDriverLicenseTypesRepository, EFVacancyDriverLicenseTypesRepository>();
            services.AddTransient<IBusinessTripReadinessTypesRepository, EFBusinessTripReadinessTypesRepository>();
            services.AddTransient<IApplicantCommentAccessTypesRepository, EFApplicantCommentAccessTypesRepository>();
            services.AddTransient<IApplicantNegotiationStatusesRepository, EFApplicantNegotiationStatusesRepository>();
            services.AddTransient<IEmployerActiveVacanciesOrdersRepository, EFEmployerActiveVacanciesOrdersRepository>();
            services.AddTransient<IEmployerArchivedVacanciesOrdersRepository, EFEmployerArchivedVacanciesOrdersRepository>();
            services.AddTransient<DataManager>();

            services.AddDbContext<OnlineRecruitingPlatformDbContext>((options) =>
            {
                options.UseSqlServer(Config.ConnectionString);
            });

            services.AddControllersWithViews(x =>
            {

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
