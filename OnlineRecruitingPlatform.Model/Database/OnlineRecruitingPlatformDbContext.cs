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
        
        public DbSet<CertificateType> CertificateTypes { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<CompanyContact> CompanyContacts { get; set; }

        public DbSet<CompanyContactPhone> CompanyContactPhones { get; set; }

        public DbSet<CompanyInformation> CompanyInformation { get; set; }

        public DbSet<CompanyInsiderInterview> CompanyInsiderInterviews { get; set; }

        public DbSet<CompanyLocation> CompanyLocations { get; set; }

        public DbSet<CompanyLogo> CompanyLogos { get; set; }

        public DbSet<CompanyPhoto> CompanyPhotos { get; set; }

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
        
        public DbSet<PreferredContactType> PreferredContactTypes { get; set; }

        public DbSet<Profession> Professions { get; set; }

        public DbSet<ProfessionalArea> ProfessionalAreas { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Relation> Relations { get; set; }
        
        public DbSet<RelocationType> RelocationTypes { get; set; }
        
        public DbSet<Resume> Resumes { get; set; }
        
        public DbSet<ResumeCertificate> ResumeCertificates { get; set; }
        
        public DbSet<ResumeCitizenship> ResumeCitizenship { get; set; }
        
        public DbSet<ResumeContact> ResumeContacts { get; set; }
        
        public DbSet<ResumeContactPhone> ResumeContactPhones { get; set; }
        
        public DbSet<ResumeContactsSiteType> ResumeContactsSiteTypes { get; set; }
        
        public DbSet<ResumeDriverLicenseType> ResumeDriverLicenseTypes { get; set; }
        
        public DbSet<ResumeEducation> ResumeEducations { get; set; }
        
        public DbSet<ResumeEducationAdditional> ResumeEducationAdditional { get; set; }
        
        public DbSet<ResumeEducationAttestation> ResumeEducationAttestations { get; set; }
        
        public DbSet<ResumeEducationElementary> ResumeEducationElementary { get; set; }
        
        public DbSet<ResumeEducationPrimary> ResumeEducationPrimaries { get; set; }
        
        public DbSet<ResumeEmployment> ResumeEmployments { get; set; }
        
        public DbSet<ResumeExperience> ResumeExperiences { get; set; }
        
        public DbSet<ResumeKeySkill> ResumeKeySkills { get; set; }
        
        public DbSet<ResumeLanguage> ResumeLanguages { get; set; }
        
        public DbSet<ResumePhoto> ResumePhotos { get; set; }
        
        public DbSet<ResumePortfolio> ResumePortfolios { get; set; }
        
        public DbSet<ResumeRecommendation> ResumeRecommendations { get; set; }
        
        public DbSet<ResumeRelocation> ResumeRelocation { get; set; }
        
        public DbSet<ResumeRelocationArea> ResumeRelocationAreas { get; set; }
        
        public DbSet<ResumeSalary> ResumeSalaries { get; set; }
        
        public DbSet<ResumeSchedule> ResumeSchedules { get; set; }
        
        public DbSet<ResumeSite> ResumeSites { get; set; }
        
        public DbSet<ResumeSkill> ResumeSkills { get; set; }
        
        public DbSet<ResumeSpecialization> ResumeSpecializations { get; set; }
        
        public DbSet<ResumeStatus> ResumeStatuses { get; set; }
        
        public DbSet<ResumeTotalExperience> ResumeTotalExperiences { get; set; }
        
        public DbSet<ResumeTravelTime> ResumeTravelTimes { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Specialization> Specializations { get; set; }
        
        public DbSet<Street> Streets { get; set; }

        public DbSet<SubIndustry> SubIndustries { get; set; }
        
        public DbSet<TravelTime> TravelTimes { get; set; }
        
        public DbSet<University> Universities { get; set; }
        
        public DbSet<UniversityFaculty> UniversityFaculties { get; set; }

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
        
        public DbSet<VacancyVisibilityType> VacancyVisibilityTypes { get; set; }

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
                optionsBuilder
                    .UseLazyLoadingProxies()    
                    .UseSqlServer("Server=DESKTOP-9CDGA5B;Database=OnlineRecruitingPlatform;User ID=sa;Password=sa;Trusted_Connection=True;", b => b.MigrationsAssembly("OnlineRecruitingPlatform.DevExtremeAspNetCore"));
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

            builder.Entity<Country>()
                .HasMany(c => c.ResumeCitizenship)
                .WithOne(r => r.Country)
                .HasForeignKey(r => r.CountryId);

            builder.Entity<Region>()
                .HasMany(r => r.Areas)
                .WithOne(a => a.Region)
                .HasForeignKey(a => a.RegionId);

            builder.Entity<CertificateType>()
                .HasMany(c => c.ResumeCertificates)
                .WithOne(r => r.CertificateType)
                .HasForeignKey(r => r.CertificateTypeId);

            builder.Entity<Company>()
                .HasOne(c => c.Information)
                .WithOne(ci => ci.Company)
                .HasForeignKey<CompanyInformation>(ci => ci.CompanyId);

            builder.Entity<Company>()
                .HasOne(c => c.Logo)
                .WithOne(cl => cl.Company)
                .HasForeignKey<CompanyLogo>(cl => cl.CompanyId);

            builder.Entity<Company>()
                .HasMany(c => c.CompanyPhotos)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

            builder.Entity<Company>()
                .HasMany(c => c.CompanyContacts)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

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

            builder.Entity<Company>()
                .HasMany(c => c.ResumeExperiences)
                .WithOne(r => r.Company)
                .HasForeignKey(r => r.CompanyId);

            builder.Entity<CompanyContact>()
                .HasMany(c => c.CompanyContactPhones)
                .WithOne(c => c.CompanyContact)
                .HasForeignKey(c => c.CompanyContactId);

            builder.Entity<Relation>()
                .HasMany(r => r.CompanyRelations)
                .WithOne(cr => cr.Relation)
                .HasForeignKey(cr => cr.RelationId);

            builder.Entity<RelocationType>()
                .HasMany(r => r.ResumeRelocation)
                .WithOne(r => r.RelocationType)
                .HasForeignKey(r => r.RelocationTypeId);

            builder.Entity<Resume>()
                .HasOne(r => r.ResumeSkill)
                .WithOne(r => r.Resume)
                .HasForeignKey<ResumeSkill>(r => r.ResumeId);

            builder.Entity<Resume>()
                .HasOne(r => r.ResumePhoto)
                .WithOne(r => r.Resume)
                .HasForeignKey<ResumePhoto>(r => r.ResumeId);

            builder.Entity<Resume>()
                .HasOne(r => r.ResumeSalary)
                .WithOne(r => r.Resume)
                .HasForeignKey<ResumeSalary>(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasOne(r => r.ResumeEducation)
                .WithOne(r => r.Resume)
                .HasForeignKey<ResumeEducation>(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasOne(r => r.ResumeRelocation)
                .WithOne(r => r.Resume)
                .HasForeignKey<ResumeRelocation>(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasOne(r => r.ResumeTravelTime)
                .WithOne(r => r.Resume)
                .HasForeignKey<ResumeTravelTime>(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasOne(r => r.ResumeTotalExperience)
                .WithOne(r => r.Resume)
                .HasForeignKey<ResumeTotalExperience>(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeDriverLicenseTypes)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeSpecializations)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeRecommendations)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeCertificates)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeCitizenship)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeEmployments)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeExperiences)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumePortfolios)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeSchedules)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeLanguages)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeKeySkills)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeContacts)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeContacts)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<Resume>()
                .HasMany(r => r.ResumeSites)
                .WithOne(r => r.Resume)
                .HasForeignKey(r => r.ResumeId);
            
            builder.Entity<ResumeContact>()
                .HasOne(r => r.ResumeContactPhone)
                .WithOne(r => r.ResumeContact)
                .HasForeignKey<ResumeContactPhone>(r => r.ResumeContactPhoneId);
            
            builder.Entity<ResumeContactsSiteType>()
                .HasMany(r => r.ResumeSites)
                .WithOne(r => r.ResumeContactsSiteType)
                .HasForeignKey(r => r.ResumeContactsSiteTypeId);
            
            builder.Entity<ResumeEducation>()
                .HasMany(r => r.ResumeEducationPrimaries)
                .WithOne(r => r.ResumeEducation)
                .HasForeignKey(r => r.ResumeEducationId);
            
            builder.Entity<ResumeEducation>()
                .HasMany(r => r.ResumeEducationElementary)
                .WithOne(r => r.ResumeEducation)
                .HasForeignKey(r => r.ResumeEducationId);
            
            builder.Entity<ResumeEducation>()
                .HasMany(r => r.ResumeEducationAdditionally)
                .WithOne(r => r.ResumeEducation)
                .HasForeignKey(r => r.ResumeEducationId);
            
            builder.Entity<ResumeEducation>()
                .HasMany(r => r.ResumeEducationAttestations)
                .WithOne(r => r.ResumeEducation)
                .HasForeignKey(r => r.ResumeEducationId);
            
            builder.Entity<ResumeRelocation>()
                .HasMany(r => r.ResumeRelocationAreas)
                .WithOne(r => r.ResumeRelocation)
                .HasForeignKey(r => r.ResumeRelocationId);
            
            builder.Entity<ResumeStatus>()
                .HasMany(r => r.Resumes)
                .WithOne(r => r.ResumeStatus)
                .HasForeignKey(r => r.ResumeStatusId);

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

            builder.Entity<Area>()
                .HasMany(a => a.ResumeExperiences)
                .WithOne(r => r.Area)
                .HasForeignKey(r => r.AreaId);

            builder.Entity<Area>()
                .HasMany(a => a.ResumeRelocationAreas)
                .WithOne(r => r.Area)
                .HasForeignKey(r => r.AreaId);

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

            builder.Entity<Currency>()
                .HasMany(c => c.ResumeSalaries)
                .WithOne(r => r.Currency)
                .HasForeignKey(r => r.CurrencyId);

            builder.Entity<EducationLevel>()
                .HasMany(e => e.Vacancies)
                .WithOne(v => v.EducationLevel)
                .HasForeignKey(v => v.EducationLevelId);

            builder.Entity<EducationLevel>()
                .HasMany(e => e.ResumeEducations)
                .WithOne(r => r.EducationLevel)
                .HasForeignKey(r => r.EducationLevelId);

            builder.Entity<Employment>()
                .HasMany(e => e.Vacancies)
                .WithOne(v => v.Employment)
                .HasForeignKey(v => v.EmploymentId);

            builder.Entity<Employment>()
                .HasMany(e => e.ResumeEmployments)
                .WithOne(r => r.Employment)
                .HasForeignKey(r => r.EmploymentId);

            builder.Entity<Experience>()
                .HasMany(e => e.Vacancies)
                .WithOne(v => v.Experience)
                .HasForeignKey(v => v.ExperienceId);

            builder.Entity<Gender>()
                .HasMany(g => g.Resumes)
                .WithOne(r => r.Gender)
                .HasForeignKey(r => r.GenderId);

            builder.Entity<Language>()
                .HasMany(l => l.ResumeLanguages)
                .WithOne(r => r.Language)
                .HasForeignKey(l => l.LanguageId);

            builder.Entity<LanguageLevel>()
                .HasMany(l => l.ResumeLanguages)
                .WithOne(r => r.LanguageLevel)
                .HasForeignKey(r => r.LanguageLevelId);

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

            builder.Entity<PreferredContactType>()
                .HasMany(p => p.ResumeContacts)
                .WithOne(r => r.PreferredContactType)
                .HasForeignKey(r => r.PreferredContactTypeId);

            builder.Entity<Profession>()
                .HasMany(p => p.Vacancies)
                .WithOne(v => v.Profession)
                .HasForeignKey(v => v.ProfessionId);

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
            
            builder.Entity<Schedule>()
                .HasMany(s => s.ResumeSchedules)
                .WithOne(v => v.Schedule)
                .HasForeignKey(v => v.ScheduleId);

            builder.Entity<Specialization>()
                .HasMany(s => s.VacancySpecializations)
                .WithOne(v => v.Specialization)
                .HasForeignKey(v => v.SpecializationId);
            
            builder.Entity<Specialization>()
                .HasMany(s => s.ResumeSpecializations)
                .WithOne(r => r.Specialization)
                .HasForeignKey(r => r.SpecializationId);

            builder.Entity<TravelTime>()
                .HasMany(t => t.ResumeTravelTimes)
                .WithOne(r => r.TravelTime)
                .HasForeignKey(r => r.TravelTimeId);
            
            builder.Entity<University>()
                .HasMany(u => u.UniversityFaculties)
                .WithOne(u => u.University)
                .HasForeignKey(u => u.UniversityId);
            
            builder.Entity<UniversityFaculty>()
                .HasMany(u => u.ResumeEducationPrimaries)
                .WithOne(r => r.UniversityFaculty)
                .HasForeignKey(r => r.UniversityFacultyId);

            builder.Entity<Building>()
                .HasMany(b => b.Addresses)
                .WithOne(a => a.Building)
                .HasForeignKey(a => a.BuildingId);

            builder.Entity<BusinessTripReadiness>()
                .HasMany(b => b.Resumes)
                .WithOne(r => r.BusinessTripReadiness)
                .HasForeignKey(b => b.BusinessTripReadinessId);

            builder.Entity<Address>()
                .HasMany(a => a.Vacancies)
                .WithOne(v => v.Address)
                .HasForeignKey(v => v.AddressId);

            builder.Entity<Address>()
                .HasMany(a => a.CompanyContacts)
                .WithOne(c => c.Address)
                .HasForeignKey(c => c.AddressId);

            builder.Entity<Address>()
                .HasMany(a => a.VacancyContacts)
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

            builder.Entity<DriverLicenseType>()
                .HasMany(d => d.ResumeDriverLicenseTypes)
                .WithOne(r => r.DriverLicenseType)
                .HasForeignKey(r => r.DriverLicenseTypeId);

            builder.Entity<Skill>()
                .HasMany(s => s.VacancyKeySkills)
                .WithOne(v => v.Skill)
                .HasForeignKey(v => v.SkillId);
            
            builder.Entity<Skill>()
                .HasMany(s => s.ResumeKeySkills)
                .WithOne(v => v.Skill)
                .HasForeignKey(v => v.SkillId);

            builder.Entity<VacancyType>()
                .HasMany(v => v.Vacancies)
                .WithOne(v => v.VacancyType)
                .HasForeignKey(v => v.VacancyTypeId);

            builder.Entity<VacancyVisibilityType>()
                .HasMany(v => v.Vacancies)
                .WithOne(v => v.VacancyVisibilityType)
                .HasForeignKey(v => v.VacancyVisibilityTypeId);

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
