using FIASApi.Response.RestClients.Addrobs;
using FIASApi.Response.RestClients.Houses;
using FIASApi.Response.RestClients.Rooms;
using FIASApi.Response.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineRecruitingPlatform.DevExtremeAspNetCore.Service;
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

            ConfigRestClients.Protocol = ConfigFIASApi.Protocol;
            ConfigRestClients.Domain = ConfigFIASApi.Domain;
            ConfigRestClients.Port = ConfigFIASApi.Port;

            services.AddTransient<AreasRestClient>();
            services.AddTransient<FlatsRestClient>();
            services.AddTransient<CitiesRestClient>();
            services.AddTransient<PlacesRestClient>();
            services.AddTransient<HousesRestClient>();
            services.AddTransient<RegionsRestClient>();
            services.AddTransient<StreetsRestClient>();
            services.AddTransient<OfficesRestClient>();

            services.AddTransient<IApplicantCommentAccessTypesRepository, EFApplicantCommentAccessTypesRepository>();
            services.AddTransient<IApplicantCommentsOrdersRepository, EFApplicantCommentsOrdersRepository>();
            services.AddTransient<IIdentityRolesRepository, EFIdentityRolesRepository>();
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
                options.Cookie.Name = "myCompanyAuth";
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
