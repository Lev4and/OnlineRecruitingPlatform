using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database
{
    public class OnlineRecruitingPlatformDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ApplicantCommentAccessType> ApplicantCommentAccessTypes { get; set; }

        public DbSet<ApplicantCommentsOrder> ApplicantCommentsOrders { get; set; }

        public DbSet<ApplicantNegotiationStatus> ApplicantNegotiationStatuses { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<BusinessTripReadiness> BusinessTripReadinessTypes { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyInformation> CompanyInformation { get; set; }

        public DbSet<CompanyInsiderInterview> CompanyInsiderInterviews { get; set; }

        public DbSet<CompanyLocation> CompanyLocations { get; set; }

        public DbSet<CompanyLogo> CompanyLogos { get; set; }

        public DbSet<CompanyRelation> CompanyRelations { get; set; }

        public DbSet<CompanySubIndustry> CompanySubIndustries { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<DriverLicenseType> DriverLicenseTypes { get; set; }

        public DbSet<EducationLevel> EducationLevels { get; set; }

        public DbSet<EmployerActiveVacanciesOrder> EmployerActiveVacanciesOrders { get; set; }

        public DbSet<EmployerArchivedVacanciesOrder> EmployerArchivedVacanciesOrders { get; set; }

        public DbSet<EmployerRelation> EmployerRelations { get; set; }

        public DbSet<EmployerType> EmployerTypes { get; set; }

        public DbSet<Employment> Employments { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Industry> Industries { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<LanguageLevel> LanguageLevels { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Relation> Relations { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<SubIndustry> SubIndustries { get; set; }

        public OnlineRecruitingPlatformDbContext(DbContextOptions<OnlineRecruitingPlatformDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9CDGA5B;Database=OnlineRecruitingPlatform;User ID=sa;Password=sa;Trusted_Connection=True;", b => b.MigrationsAssembly("OnlineRecruitingPlatform.DevExtremeAspNetCore"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "B867520A-92DB-4658-BE39-84DA53A601C0",
                Name = "Администратор",
                NormalizedName = "АДМИНИСТРАТОР"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                Name = "Соискатель",
                NormalizedName = "СОИСКАТЕЛЬ"
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                Name = "Работодатель",
                NormalizedName = "РАБОТОДАТЕЛЬ"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "andrey.levchenko.2001@gmail.com",
                NormalizedEmail = "ANDREY.LEVCHENKO.2001@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "!Lev4and*"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "B867520A-92DB-4658-BE39-84DA53A601C0",
                UserId = "21F7B496-C675-4E8A-A34C-FC5EC0762FDB"
            });

            builder.Entity<Industry>()
                .HasMany(i => i.SubIndustries)
                .WithOne(s => s.Industry)
                .HasForeignKey(s => s.IndustryId);

            builder.Entity<Country>()
                .HasMany(c => c.Regions)
                .WithOne(r => r.Country)
                .HasForeignKey(r => r.CountryId);

            builder.Entity<Region>()
                .HasMany(r => r.Areas)
                .WithOne(a => a.Region)
                .HasForeignKey(a => a.RegionId);

            builder.Entity<Company>()
                .HasOne(c => c.Information)
                .WithOne(ci => ci.Company)
                .HasForeignKey<CompanyInformation>(ci => ci.CompanyId);

            builder.Entity<Company>()
                .HasOne(c => c.Logo)
                .WithOne(cl => cl.Company)
                .HasForeignKey<CompanyLogo>(cl => cl.CompanyId);

            builder.Entity<Company>()
                .HasMany(c => c.Relations)
                .WithOne(cr => cr.Company)
                .HasForeignKey(cr => cr.CompanyId);

            builder.Entity<Company>()
                .HasMany(c => c.Locations)
                .WithOne(cl => cl.Company)
                .HasForeignKey(cl => cl.CompanyId);

            builder.Entity<Company>()
                .HasMany(c => c.SubIndustries)
                .WithOne(cs => cs.Company)
                .HasForeignKey(cs => cs.CompanyId);

            builder.Entity<Company>()
                .HasMany(c => c.InsiderInterviews)
                .WithOne(ci => ci.Company)
                .HasForeignKey(ci => ci.CompanyId);

            builder.Entity<Relation>()
                .HasMany(r => r.CompanyRelations)
                .WithOne(cr => cr.Relation)
                .HasForeignKey(cr => cr.RelationId);

            builder.Entity<Area>()
                .HasMany(a => a.CompanyLocations)
                .WithOne(cl => cl.Area)
                .HasForeignKey(cl => cl.AreaId);

            builder.Entity<SubIndustry>()
                .HasMany(s => s.CompanySubIndustries)
                .WithOne(cs => cs.SubIndustry)
                .HasForeignKey(cs => cs.SubIndustryId);
        }
    }
}
