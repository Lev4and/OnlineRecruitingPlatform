using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddNewEntitiesDependingWithResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CertificateTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreferredContactTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelocationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelocationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeContactsSiteTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeContactsSiteTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResumeStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<int>(type: "int", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Synonyms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ResumeStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BusinessTripReadinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasVehicle = table.Column<bool>(type: "bit", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentifierFromHeadHunter = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumes_BusinessTripReadinessTypes_BusinessTripReadinessId",
                        column: x => x.BusinessTripReadinessId,
                        principalTable: "BusinessTripReadinessTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resumes_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Resumes_ResumeStatuses_ResumeStatusId",
                        column: x => x.ResumeStatusId,
                        principalTable: "ResumeStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UniversityFaculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityFaculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityFaculties_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeCertificates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificateTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AchievedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeCertificates_CertificateTypes_CertificateTypeId",
                        column: x => x.CertificateTypeId,
                        principalTable: "CertificateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeCertificates_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeCitizenship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeCitizenship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeCitizenship_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeCitizenship_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreferredContactTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeContacts_PreferredContactTypes_PreferredContactTypeId",
                        column: x => x.PreferredContactTypeId,
                        principalTable: "PreferredContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeContacts_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeDriverLicenseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverLicenseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeDriverLicenseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeDriverLicenseTypes_DriverLicenseTypes_DriverLicenseTypeId",
                        column: x => x.DriverLicenseTypeId,
                        principalTable: "DriverLicenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeDriverLicenseTypes_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeEducations_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeEducations_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeEmployments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmploymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeEmployments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeEmployments_Employments_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Employments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeEmployments_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeExperiences_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResumeExperiences_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResumeExperiences_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeKeySkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeKeySkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeKeySkills_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeKeySkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeLanguages_LanguageLevels_LanguageLevelId",
                        column: x => x.LanguageLevelId,
                        principalTable: "LanguageLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeLanguages_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumePhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Small = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumePhotos_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumePortfolios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Small = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumePortfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumePortfolios_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeRecommendations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeRecommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeRecommendations_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeRelocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelocationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeRelocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeRelocation_RelocationTypes_RelocationTypeId",
                        column: x => x.RelocationTypeId,
                        principalTable: "RelocationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeRelocation_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSalaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSalaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeSalaries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeSalaries_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeSchedules_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeSchedules_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeContactsSiteTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeSites_ResumeContactsSiteTypes_ResumeContactsSiteTypeId",
                        column: x => x.ResumeContactsSiteTypeId,
                        principalTable: "ResumeContactsSiteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeSites_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeSkills_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeSpecializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeSpecializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeSpecializations_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeSpecializations_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeTotalExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Months = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeTotalExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeTotalExperiences_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeTravelTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeTravelTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeTravelTimes_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeTravelTimes_TravelTimes_TravelTimeId",
                        column: x => x.TravelTimeId,
                        principalTable: "TravelTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeContactPhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeContactPhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formatted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeContactPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeContactPhones_ResumeContacts_ResumeContactPhoneId",
                        column: x => x.ResumeContactPhoneId,
                        principalTable: "ResumeContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeEducationAdditional",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeEducationAdditional", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeEducationAdditional_ResumeEducations_ResumeEducationId",
                        column: x => x.ResumeEducationId,
                        principalTable: "ResumeEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeEducationAttestations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeEducationAttestations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeEducationAttestations_ResumeEducations_ResumeEducationId",
                        column: x => x.ResumeEducationId,
                        principalTable: "ResumeEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeEducationElementary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeEducationElementary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeEducationElementary_ResumeEducations_ResumeEducationId",
                        column: x => x.ResumeEducationId,
                        principalTable: "ResumeEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeEducationPrimaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeEducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniversityFacultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeEducationPrimaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeEducationPrimaries_ResumeEducations_ResumeEducationId",
                        column: x => x.ResumeEducationId,
                        principalTable: "ResumeEducations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeEducationPrimaries_UniversityFaculties_UniversityFacultyId",
                        column: x => x.UniversityFacultyId,
                        principalTable: "UniversityFaculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResumeRelocationAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeRelocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeRelocationAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumeRelocationAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResumeRelocationAreas_ResumeRelocation_ResumeRelocationId",
                        column: x => x.ResumeRelocationId,
                        principalTable: "ResumeRelocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "b83bf03d-6204-469e-9027-ed44b9727080");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "9584c071-6850-4e6f-86e6-3c69e908d4a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "e7f7334b-cc4f-4dcd-8228-c559f1834315");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb2fbeb2-4838-4943-a176-f4e47ff1b067", "AQAAAAEAACcQAAAAEOcSzpbdRSuCntkxYtzPTWSriuWAFXF5BaJMVHrOPM1jZaZZOfFxtPOMMdhX3CVXpw==" });

            migrationBuilder.CreateIndex(
                name: "IX_ResumeCertificates_CertificateTypeId",
                table: "ResumeCertificates",
                column: "CertificateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeCertificates_ResumeId",
                table: "ResumeCertificates",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeCitizenship_CountryId",
                table: "ResumeCitizenship",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeCitizenship_ResumeId",
                table: "ResumeCitizenship",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeContactPhones_ResumeContactPhoneId",
                table: "ResumeContactPhones",
                column: "ResumeContactPhoneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeContacts_PreferredContactTypeId",
                table: "ResumeContacts",
                column: "PreferredContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeContacts_ResumeId",
                table: "ResumeContacts",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeDriverLicenseTypes_DriverLicenseTypeId",
                table: "ResumeDriverLicenseTypes",
                column: "DriverLicenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeDriverLicenseTypes_ResumeId",
                table: "ResumeDriverLicenseTypes",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducationAdditional_ResumeEducationId",
                table: "ResumeEducationAdditional",
                column: "ResumeEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducationAttestations_ResumeEducationId",
                table: "ResumeEducationAttestations",
                column: "ResumeEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducationElementary_ResumeEducationId",
                table: "ResumeEducationElementary",
                column: "ResumeEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducationPrimaries_ResumeEducationId",
                table: "ResumeEducationPrimaries",
                column: "ResumeEducationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducationPrimaries_UniversityFacultyId",
                table: "ResumeEducationPrimaries",
                column: "UniversityFacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducations_EducationLevelId",
                table: "ResumeEducations",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEducations_ResumeId",
                table: "ResumeEducations",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEmployments_EmploymentId",
                table: "ResumeEmployments",
                column: "EmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeEmployments_ResumeId",
                table: "ResumeEmployments",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperiences_AreaId",
                table: "ResumeExperiences",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperiences_CompanyId",
                table: "ResumeExperiences",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeExperiences_ResumeId",
                table: "ResumeExperiences",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeKeySkills_ResumeId",
                table: "ResumeKeySkills",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeKeySkills_SkillId",
                table: "ResumeKeySkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeLanguages_LanguageId",
                table: "ResumeLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeLanguages_LanguageLevelId",
                table: "ResumeLanguages",
                column: "LanguageLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeLanguages_ResumeId",
                table: "ResumeLanguages",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumePhotos_ResumeId",
                table: "ResumePhotos",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumePortfolios_ResumeId",
                table: "ResumePortfolios",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeRecommendations_ResumeId",
                table: "ResumeRecommendations",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeRelocation_RelocationTypeId",
                table: "ResumeRelocation",
                column: "RelocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeRelocation_ResumeId",
                table: "ResumeRelocation",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeRelocationAreas_AreaId",
                table: "ResumeRelocationAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeRelocationAreas_ResumeRelocationId",
                table: "ResumeRelocationAreas",
                column: "ResumeRelocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_BusinessTripReadinessId",
                table: "Resumes",
                column: "BusinessTripReadinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_GenderId",
                table: "Resumes",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ResumeStatusId",
                table: "Resumes",
                column: "ResumeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSalaries_CurrencyId",
                table: "ResumeSalaries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSalaries_ResumeId",
                table: "ResumeSalaries",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSchedules_ResumeId",
                table: "ResumeSchedules",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSchedules_ScheduleId",
                table: "ResumeSchedules",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSites_ResumeContactsSiteTypeId",
                table: "ResumeSites",
                column: "ResumeContactsSiteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSites_ResumeId",
                table: "ResumeSites",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSkills_ResumeId",
                table: "ResumeSkills",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSpecializations_ResumeId",
                table: "ResumeSpecializations",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeSpecializations_SpecializationId",
                table: "ResumeSpecializations",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTotalExperiences_ResumeId",
                table: "ResumeTotalExperiences",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTravelTimes_ResumeId",
                table: "ResumeTravelTimes",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumeTravelTimes_TravelTimeId",
                table: "ResumeTravelTimes",
                column: "TravelTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityFaculties_UniversityId",
                table: "UniversityFaculties",
                column: "UniversityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResumeCertificates");

            migrationBuilder.DropTable(
                name: "ResumeCitizenship");

            migrationBuilder.DropTable(
                name: "ResumeContactPhones");

            migrationBuilder.DropTable(
                name: "ResumeDriverLicenseTypes");

            migrationBuilder.DropTable(
                name: "ResumeEducationAdditional");

            migrationBuilder.DropTable(
                name: "ResumeEducationAttestations");

            migrationBuilder.DropTable(
                name: "ResumeEducationElementary");

            migrationBuilder.DropTable(
                name: "ResumeEducationPrimaries");

            migrationBuilder.DropTable(
                name: "ResumeEmployments");

            migrationBuilder.DropTable(
                name: "ResumeExperiences");

            migrationBuilder.DropTable(
                name: "ResumeKeySkills");

            migrationBuilder.DropTable(
                name: "ResumeLanguages");

            migrationBuilder.DropTable(
                name: "ResumePhotos");

            migrationBuilder.DropTable(
                name: "ResumePortfolios");

            migrationBuilder.DropTable(
                name: "ResumeRecommendations");

            migrationBuilder.DropTable(
                name: "ResumeRelocationAreas");

            migrationBuilder.DropTable(
                name: "ResumeSalaries");

            migrationBuilder.DropTable(
                name: "ResumeSchedules");

            migrationBuilder.DropTable(
                name: "ResumeSites");

            migrationBuilder.DropTable(
                name: "ResumeSkills");

            migrationBuilder.DropTable(
                name: "ResumeSpecializations");

            migrationBuilder.DropTable(
                name: "ResumeTotalExperiences");

            migrationBuilder.DropTable(
                name: "ResumeTravelTimes");

            migrationBuilder.DropTable(
                name: "CertificateTypes");

            migrationBuilder.DropTable(
                name: "ResumeContacts");

            migrationBuilder.DropTable(
                name: "ResumeEducations");

            migrationBuilder.DropTable(
                name: "UniversityFaculties");

            migrationBuilder.DropTable(
                name: "ResumeRelocation");

            migrationBuilder.DropTable(
                name: "ResumeContactsSiteTypes");

            migrationBuilder.DropTable(
                name: "TravelTimes");

            migrationBuilder.DropTable(
                name: "PreferredContactTypes");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "RelocationTypes");

            migrationBuilder.DropTable(
                name: "Resumes");

            migrationBuilder.DropTable(
                name: "ResumeStatuses");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "3a930a53-c99b-43b4-9566-b39468479d38");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "873848a8-bb5e-42fd-877d-8c33e72de8ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "0d4f91ef-d07b-4c31-adde-cbdbce11c42b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd53f2ad-23dc-4e50-94cc-c0afaf83ba54", "AQAAAAEAACcQAAAAEB+8n2Sf4lfsnAszp3HNlljvQGH4Rf3siqo/MO0IW92oz1vf+6PNRdSGgppYXcI6aA==" });
        }
    }
}
