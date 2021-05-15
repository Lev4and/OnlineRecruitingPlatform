using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class RemoveEntityVacancyProfession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacancyProfessions");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "VacancyContactPhones",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "VacancyContactPhones",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<string>(
                name: "CityCode",
                table: "VacancyContactPhones",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "CompanyInsiderInterviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardCompanyUrl",
                table: "CompanyInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CompanyInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlacklisted",
                table: "Companies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Companies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCommerce",
                table: "Companies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHolding",
                table: "Companies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHr",
                table: "Companies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifierFromZarplataRu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContacts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyContacts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromZarplataRu = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyPhotos_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContactPhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    CityCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Number = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formatted = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContactPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContactPhones_CompanyContacts_CompanyContactId",
                        column: x => x.CompanyContactId,
                        principalTable: "CompanyContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "e3ed7129-d7fd-4ce7-81e8-2e794bd9bb70");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "094ce09d-a3b2-4e21-8c58-9986ca4cbaaf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "b8a6b2bf-b143-4935-8d35-52ba73f7233e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2a43cda3-40f3-4d9d-a49f-569d56b9b7c0", "AQAAAAEAACcQAAAAEKIK3dduFsPBtBSIbPA++sSjdJfsTC3V17h37/eOjO9+7dWNhYHX4d8FGnpwSFWymw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_ProfessionId",
                table: "Vacancies",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContactPhones_CompanyContactId",
                table: "CompanyContactPhones",
                column: "CompanyContactId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContacts_AddressId",
                table: "CompanyContacts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContacts_CompanyId",
                table: "CompanyContacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPhotos_CompanyId",
                table: "CompanyPhotos",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Professions_ProfessionId",
                table: "Vacancies",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Professions_ProfessionId",
                table: "Vacancies");

            migrationBuilder.DropTable(
                name: "CompanyContactPhones");

            migrationBuilder.DropTable(
                name: "CompanyPhotos");

            migrationBuilder.DropTable(
                name: "CompanyContacts");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_ProfessionId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "CompanyInsiderInterviews");

            migrationBuilder.DropColumn(
                name: "CardCompanyUrl",
                table: "CompanyInformation");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CompanyInformation");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsBlacklisted",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsCommerce",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsHolding",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsHr",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "VacancyContactPhones",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CountryCode",
                table: "VacancyContactPhones",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CityCode",
                table: "VacancyContactPhones",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "VacancyProfessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyProfessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyProfessions_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyProfessions_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "f5b03bca-9688-4161-8a23-5706115a0e44");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "aa3288e7-5be7-4a75-878c-bfa8edcd6948");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "faf33840-14ce-407a-ae98-dde11740dae6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bff95acc-7fab-400c-92d3-772f03a3ae7b", "AQAAAAEAACcQAAAAENH9gnwNlDXegNQDJOF/HvyU2hCrQjdc9KX2ffztBPUsXkJNbuF5JlXSLZeiGsmkrA==" });

            migrationBuilder.CreateIndex(
                name: "IX_VacancyProfessions_ProfessionId",
                table: "VacancyProfessions",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyProfessions_VacancyId",
                table: "VacancyProfessions",
                column: "VacancyId");
        }
    }
}
