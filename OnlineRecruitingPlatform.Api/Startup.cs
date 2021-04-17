using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineRecruitingPlatform.Api.Service;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Repositories.Abstract;
using OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework;

namespace OnlineRecruitingPlatform.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("ConfigDb", new ConfigDb());

            services.AddTransient<ISkillsRepository, EFSkillsRepository>();
            services.AddTransient<IGendersRepository, EFGendersRepository>();
            services.AddTransient<ILanguagesRepository, EFLanguagesRepository>();
            services.AddTransient<ICurrenciesRepository, EFCurrenciesRepository>();
            services.AddTransient<IEmploymentsRepository, EFEmploymentsRepository>();
            services.AddTransient<IExperiencesRepository, EFExperiencesRepository>();
            services.AddTransient<IEmployerTypesRepository, EFEmployerTypesRepository>();
            services.AddTransient<IIdentityRolesRepository, EFIdentityRolesRepository>();
            services.AddTransient<ILanguageLevelsRepository, EFLanguageLevelsRepository>();
            services.AddTransient<IEducationLevelsRepository, EFEducationLevelsRepository>();
            services.AddTransient<IEmployerRelationsRepository, EFEmployerRelationsRepository>();
            services.AddTransient<IDriverLicenseTypesRepository, EFDriverLicenseTypesRepository>();
            services.AddTransient<IApplicantCommentsOrdersRepository, EFApplicantCommentsOrdersRepository>();
            services.AddTransient<IBusinessTripReadinessTypesRepository, EFBusinessTripReadinessTypesRepository>();
            services.AddTransient<IApplicantCommentAccessTypesRepository, EFApplicantCommentAccessTypesRepository>();
            services.AddTransient<IApplicantNegotiationStatusesRepository, EFApplicantNegotiationStatusesRepository>();
            services.AddTransient<IEmployerActiveVacanciesOrdersRepository, EFEmployerActiveVacanciesOrdersRepository>();
            services.AddTransient<IEmployerArchivedVacanciesOrdersRepository, EFEmployerArchivedVacanciesOrdersRepository>();
            services.AddTransient<DataManager>();

            services.AddDbContext<OnlineRecruitingPlatformDbContext>((options) =>
            {
                options.UseSqlServer(ConfigDb.ConnectionStringDb);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
            });
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
