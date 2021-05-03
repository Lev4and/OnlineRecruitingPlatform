using FIASApi.HttpClients.Clients.Addrobs;
using FIASApi.HttpClients.Clients.Houses;
using FIASApi.HttpClients.Clients.Rooms;
using FIASApi.HttpClients.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
            Configuration.Bind("FIASApi", new ConfigFIASApi());

            ConfigHttpClients.UserAgent = ConfigFIASApi.UserAgent;
            ConfigHttpClients.Protocol = ConfigFIASApi.Protocol;
            ConfigHttpClients.Domain = ConfigFIASApi.Domain;
            ConfigHttpClients.Port = ConfigFIASApi.Port;

            services.AddTransient<FIASApi.HttpClients.Clients.Addrobs.AreasClient>();
            services.AddTransient<FlatsClient>();
            services.AddTransient<CitiesClient>();
            services.AddTransient<PlacesClient>();
            services.AddTransient<HousesClient>();
            services.AddTransient<FIASApi.HttpClients.Clients.Addrobs.RegionsClient>();
            services.AddTransient<StreetsClient>();
            services.AddTransient<OfficesClient>();

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
            services.AddTransient<IVacancySpecializationsRepository, EFVacancySpecializationsRepository>();
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

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<OnlineRecruitingPlatformDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "onlineRecruitingPlatformAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("Администратор"); });
            });

            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
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
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapAreaControllerRoute(
                    name: "admin_area",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
