using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddNewEntitiesRelatedWithVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyQuotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nominal = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyQuotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyQuotes_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aoguid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<int>(type: "int", nullable: true),
                    IdentifierParentFromHeadHunter = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Street_Areas_Aoguid",
                        column: x => x.Aoguid,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacancyBillingType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyBillingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacancyRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyRelations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacancyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingTimeIntervals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTimeIntervals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingTimeModes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTimeModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessionalAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specializations_ProfessionalAreas_ProfessionalAreaId",
                        column: x => x.ProfessionalAreaId,
                        principalTable: "ProfessionalAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StreetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aoguid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromHeadHunter = table.Column<int>(type: "int", nullable: true),
                    IdentifierParentFromHeadHunter = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Street_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Street",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aoguid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StreetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Areas_CityId",
                        column: x => x.CityId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Street_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Street",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmploymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VacancyTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkingDaysId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkingTimeIntervalsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkingTimeModesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Archived = table.Column<bool>(type: "bit", nullable: false),
                    AcceptTemporary = table.Column<bool>(type: "bit", nullable: true),
                    AcceptHandicapped = table.Column<bool>(type: "bit", nullable: false),
                    AcceptKids = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentifierFromHeadHunter = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacancies_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacancies_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacancies_Employments_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "Employments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacancies_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancies_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancies_VacancyTypes_VacancyTypeId",
                        column: x => x.VacancyTypeId,
                        principalTable: "VacancyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacancies_WorkingDays_WorkingDaysId",
                        column: x => x.WorkingDaysId,
                        principalTable: "WorkingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacancies_WorkingTimeIntervals_WorkingTimeIntervalsId",
                        column: x => x.WorkingTimeIntervalsId,
                        principalTable: "WorkingTimeIntervals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacancies_WorkingTimeModes_WorkingTimeModesId",
                        column: x => x.WorkingTimeModesId,
                        principalTable: "WorkingTimeModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VacancyContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyContacts_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyDriverLicenseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverLicenseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyDriverLicenseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyDriverLicenseTypes_DriverLicenseTypes_DriverLicenseTypeId",
                        column: x => x.DriverLicenseTypeId,
                        principalTable: "DriverLicenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyDriverLicenseTypes_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyBillingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasTest = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyInformation_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyInformation_VacancyBillingType_VacancyBillingTypeId",
                        column: x => x.VacancyBillingTypeId,
                        principalTable: "VacancyBillingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyKeySkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyKeySkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyKeySkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyKeySkills_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancySalaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpperWageLimit = table.Column<int>(type: "int", nullable: true),
                    LowerWageLimit = table.Column<int>(type: "int", nullable: true),
                    Gross = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancySalaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancySalaries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancySalaries_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancySpecializations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpecializationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancySpecializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancySpecializations_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancySpecializations_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyContactPhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CityCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyContactPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyContactPhones_VacancyContacts_VacancyContactId",
                        column: x => x.VacancyContactId,
                        principalTable: "VacancyContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "8a98e8c8-203b-4679-ba25-189b316419cd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "520168b9-3335-4cf1-a3c5-9898f7c7be57");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "9ced4ecc-adb2-4ee8-a868-3de33bb007d6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4091e87b-5bae-43f6-82e6-ef9ad718d71c", "AQAAAAEAACcQAAAAEB4idBaMdRBPbcCWGasSiLzWIfyJZ9BxjnTToAslIG3LMknJLuVFaF4sibXzIVwLQQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BuildingId",
                table: "Addresses",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_StreetId",
                table: "Buildings",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyQuotes_CurrencyId",
                table: "CurrencyQuotes",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_ProfessionalAreaId",
                table: "Specializations",
                column: "ProfessionalAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Street_Aoguid",
                table: "Street",
                column: "Aoguid");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_AddressId",
                table: "Vacancies",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_AreaId",
                table: "Vacancies",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_EducationLevelId",
                table: "Vacancies",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_EmploymentId",
                table: "Vacancies",
                column: "EmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_ExperienceId",
                table: "Vacancies",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_ScheduleId",
                table: "Vacancies",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_VacancyTypeId",
                table: "Vacancies",
                column: "VacancyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_WorkingDaysId",
                table: "Vacancies",
                column: "WorkingDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_WorkingTimeIntervalsId",
                table: "Vacancies",
                column: "WorkingTimeIntervalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_WorkingTimeModesId",
                table: "Vacancies",
                column: "WorkingTimeModesId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyContactPhones_VacancyContactId",
                table: "VacancyContactPhones",
                column: "VacancyContactId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyContacts_VacancyId",
                table: "VacancyContacts",
                column: "VacancyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VacancyDriverLicenseTypes_DriverLicenseTypeId",
                table: "VacancyDriverLicenseTypes",
                column: "DriverLicenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyDriverLicenseTypes_VacancyId",
                table: "VacancyDriverLicenseTypes",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyInformation_VacancyBillingTypeId",
                table: "VacancyInformation",
                column: "VacancyBillingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyInformation_VacancyId",
                table: "VacancyInformation",
                column: "VacancyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VacancyKeySkills_SkillId",
                table: "VacancyKeySkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyKeySkills_VacancyId",
                table: "VacancyKeySkills",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancySalaries_CurrencyId",
                table: "VacancySalaries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancySalaries_VacancyId",
                table: "VacancySalaries",
                column: "VacancyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VacancySpecializations_SpecializationId",
                table: "VacancySpecializations",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancySpecializations_VacancyId",
                table: "VacancySpecializations",
                column: "VacancyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyQuotes");

            migrationBuilder.DropTable(
                name: "VacancyContactPhones");

            migrationBuilder.DropTable(
                name: "VacancyDriverLicenseTypes");

            migrationBuilder.DropTable(
                name: "VacancyInformation");

            migrationBuilder.DropTable(
                name: "VacancyKeySkills");

            migrationBuilder.DropTable(
                name: "VacancyRelations");

            migrationBuilder.DropTable(
                name: "VacancySalaries");

            migrationBuilder.DropTable(
                name: "VacancySpecializations");

            migrationBuilder.DropTable(
                name: "VacancyContacts");

            migrationBuilder.DropTable(
                name: "VacancyBillingType");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "ProfessionalAreas");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "VacancyTypes");

            migrationBuilder.DropTable(
                name: "WorkingDays");

            migrationBuilder.DropTable(
                name: "WorkingTimeIntervals");

            migrationBuilder.DropTable(
                name: "WorkingTimeModes");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "7c0f2db4-dc59-4b93-a676-b9cf25fdb201");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "bb10a2df-fe5d-4ef5-914a-ae3c48ec804d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "ed522c7d-d188-4617-a2bd-7f0a084c3a24");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3950a29-a0b6-46c9-adef-4bb2d844283c", "AQAAAAEAACcQAAAAEO3hCslUzIM1r8+idyfX2l1M6AZ8GdZwlzKhtA+JTZSIxrzIXx+nSgoO1uV54r8mXg==" });
        }
    }
}
