using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.Database
{
    public class OnlineRecruitingPlatformDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<AgePreference> AgePreferences { get; set; }
        
        public DbSet<ApplicantCommentAccessType> ApplicantCommentAccessTypes { get; set; }

        public DbSet<ApplicantCommentsOrder> ApplicantCommentsOrders { get; set; }

        public DbSet<ApplicantNegotiationStatus> ApplicantNegotiationStatuses { get; set; }

        public DbSet<Area> Areas { get; set; }
        
        public DbSet<Building> Buildings { get; set; }

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

        public DbSet<CurrencyQuote> CurrencyQuotes { get; set; }

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

        public DbSet<PaidPeriod> PaidPeriods { get; set; }

        public DbSet<PayoutFrequency> PayoutFrequencies { get; set; }

        public DbSet<PlaceOfWork> PlaceOfWorks { get; set; }

        public DbSet<Profession> Professions { get; set; }

        public DbSet<ProfessionalArea> ProfessionalAreas { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Relation> Relations { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Specialization> Specializations { get; set; }
        
        public DbSet<Street> Streets { get; set; }

        public DbSet<SubIndustry> SubIndustries { get; set; }

        public DbSet<Vacancy> Vacancies { get; set; }
        
        public DbSet<VacancyBillingType> VacancyBillingTypes { get; set; }

        public DbSet<VacancyContact> VacancyContacts { get; set; }

        public DbSet<VacancyContactPhone> VacancyContactPhones { get; set; }

        public DbSet<VacancyDriverLicenseType> VacancyDriverLicenseTypes { get; set; }

        public DbSet<VacancyInformation> VacancyInformation { get; set; }

        public DbSet<VacancyKeySkill> VacancyKeySkills { get; set; }

        public DbSet<VacancyRelation> VacancyRelations { get; set; }

        public DbSet<VacancySalary> VacancySalaries { get; set; }

        public DbSet<VacancySpecialization> VacancySpecializations { get; set; }

        public DbSet<VacancyType> VacancyTypes { get; set; }

        public DbSet<WorkingDays> WorkingDays { get; set; }

        public DbSet<WorkingShift> WorkingShifts { get; set; }

        public DbSet<WorkingTimeIntervals> WorkingTimeIntervals { get; set; }

        public DbSet<WorkingTimeModes> WorkingTimeModes { get; set; }

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
                .HasMany(c => c.Vacancies)
                .WithOne(v => v.Company)
                .HasForeignKey(v => v.CompanyId);

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
                .HasMany(a => a.Streets)
                .WithOne(s => s.Area)
                .HasForeignKey(s => s.Aoguid);

            builder.Entity<Area>()
                .HasMany(a => a.Vacancies)
                .WithOne(v => v.Area)
                .HasForeignKey(v => v.AreaId);
            
            builder.Entity<Area>()
                .HasMany(a => a.Addresses)
                .WithOne(a => a.Area)
                .HasForeignKey(a => a.CityId);
            
            builder.Entity<Area>()
                .HasMany(a => a.CompanyLocations)
                .WithOne(cl => cl.Area)
                .HasForeignKey(cl => cl.AreaId);

            builder.Entity<AgePreference>()
                .HasMany(a => a.Vacancies)
                .WithOne(v => v.AgePreference)
                .HasForeignKey(v => v.AgePreferenceId);

            builder.Entity<SubIndustry>()
                .HasMany(s => s.CompanySubIndustries)
                .WithOne(cs => cs.SubIndustry)
                .HasForeignKey(cs => cs.SubIndustryId);

            builder.Entity<Street>()
                .HasMany(s => s.Buildings)
                .WithOne(b => b.Street)
                .HasForeignKey(b => b.StreetId);

            builder.Entity<Street>()
                .HasMany(s => s.Addresses)
                .WithOne(a => a.Street)
                .HasForeignKey(a => a.StreetId);

            builder.Entity<Currency>()
                .HasMany(c => c.CurrencyQuotes)
                .WithOne(c => c.Currency)
                .HasForeignKey(c => c.CurrencyId);

            builder.Entity<Currency>()
                .HasMany(c => c.VacancySalaries)
                .WithOne(v => v.Currency)
                .HasForeignKey(v => v.CurrencyId);

            builder.Entity<EducationLevel>()
                .HasMany(e => e.Vacancies)
                .WithOne(v => v.EducationLevel)
                .HasForeignKey(v => v.EducationLevelId);

            builder.Entity<Employment>()
                .HasMany(e => e.Vacancies)
                .WithOne(v => v.Employment)
                .HasForeignKey(v => v.EmploymentId);

            builder.Entity<Experience>()
                .HasMany(e => e.Vacancies)
                .WithOne(v => v.Experience)
                .HasForeignKey(v => v.ExperienceId);

            builder.Entity<PaidPeriod>()
                .HasMany(p => p.Vacancies)
                .WithOne(v => v.PayPeriod)
                .HasForeignKey(v => v.PayPeriodId);

            builder.Entity<PayoutFrequency>()
                .HasMany(p => p.Vacancies)
                .WithOne(v => v.PayoutFrequency)
                .HasForeignKey(v => v.PayoutFrequencyId);

            builder.Entity<PlaceOfWork>()
                .HasMany(p => p.Vacancies)
                .WithOne(v => v.PlaceOfWork)
                .HasForeignKey(v => v.PlaceOfWorkId);

            builder.Entity<ProfessionalArea>()
                .HasMany(p => p.Specializations)
                .WithOne(s => s.ProfessionalArea)
                .HasForeignKey(s => s.ProfessionalAreaId);

            builder.Entity<ProfessionalArea>()
                .HasMany(p => p.Vacancies)
                .WithOne(v => v.ProfessionalArea)
                .HasForeignKey(v => v.ProfessionalAreaId);

            builder.Entity<Schedule>()
                .HasMany(s => s.Vacancies)
                .WithOne(v => v.Schedule)
                .HasForeignKey(v => v.ScheduleId);

            builder.Entity<Specialization>()
                .HasMany(s => s.VacancySpecializations)
                .WithOne(v => v.Specialization)
                .HasForeignKey(v => v.SpecializationId);

            builder.Entity<Building>()
                .HasMany(b => b.Addresses)
                .WithOne(a => a.Building)
                .HasForeignKey(a => a.BuildingId);

            builder.Entity<Address>()
                .HasMany(a => a.Vacancies)
                .WithOne(v => v.Address)
                .HasForeignKey(v => v.AddressId);

            builder.Entity<Vacancy>()
                .HasOne(v => v.VacancyInformation)
                .WithOne(v => v.Vacancy)
                .HasForeignKey<VacancyInformation>(v => v.VacancyId);

            builder.Entity<Vacancy>()
                .HasOne(v => v.VacancySalary)
                .WithOne(v => v.Vacancy)
                .HasForeignKey<VacancySalary>(v => v.VacancyId);

            builder.Entity<Vacancy>()
                .HasOne(v => v.VacancyContact)
                .WithOne(v => v.Vacancy)
                .HasForeignKey<VacancyContact>(v => v.VacancyId);

            builder.Entity<Vacancy>()
                .HasMany(v => v.VacancyDriverLicenseTypes)
                .WithOne(v => v.Vacancy)
                .HasForeignKey(v => v.VacancyId);

            builder.Entity<Vacancy>()
                .HasMany(v => v.VacancyKeySkills)
                .WithOne(v => v.Vacancy)
                .HasForeignKey(v => v.VacancyId);

            builder.Entity<Vacancy>()
                .HasMany(v => v.VacancySpecializations)
                .WithOne(v => v.Vacancy)
                .HasForeignKey(v => v.VacancyId);

            builder.Entity<DriverLicenseType>()
                .HasMany(d => d.VacancyDriverLicenseTypes)
                .WithOne(v => v.DriverLicenseType)
                .HasForeignKey(v => v.DriverLicenseTypeId);

            builder.Entity<Skill>()
                .HasMany(s => s.VacancyKeySkills)
                .WithOne(v => v.Skill)
                .HasForeignKey(v => v.SkillId);

            builder.Entity<VacancyType>()
                .HasMany(v => v.Vacancies)
                .WithOne(v => v.VacancyType)
                .HasForeignKey(v => v.VacancyTypeId);

            builder.Entity<VacancyBillingType>()
                .HasMany(v => v.VacancyInformation)
                .WithOne(v => v.VacancyBillingType)
                .HasForeignKey(v => v.VacancyBillingTypeId);

            builder.Entity<VacancyContact>()
                .HasMany(v => v.VacancyContactPhones)
                .WithOne(v => v.VacancyContact)
                .HasForeignKey(v => v.VacancyContactId);

            builder.Entity<WorkingDays>()
                .HasMany(w => w.Vacancies)
                .WithOne(v => v.WorkingDays)
                .HasForeignKey(v => v.WorkingDaysId);

            builder.Entity<WorkingShift>()
                .HasMany(w => w.Vacancies)
                .WithOne(v => v.WorkingShift)
                .HasForeignKey(v => v.WorkingShiftId);

            builder.Entity<WorkingTimeIntervals>()
                .HasMany(w => w.Vacancies)
                .WithOne(v => v.WorkingTimeIntervals)
                .HasForeignKey(v => v.WorkingTimeIntervalsId);

            builder.Entity<WorkingTimeModes>()
                .HasMany(w => w.Vacancies)
                .WithOne(v => v.WorkingTimeModes)
                .HasForeignKey(v => v.WorkingTimeModesId);
        }
    }
}
