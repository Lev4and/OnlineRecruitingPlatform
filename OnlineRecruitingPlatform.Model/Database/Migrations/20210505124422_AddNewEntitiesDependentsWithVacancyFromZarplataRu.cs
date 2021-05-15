using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddNewEntitiesDependentsWithVacancyFromZarplataRu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_VacancyTypes_VacancyTypeId",
                table: "Vacancies");

            migrationBuilder.AddColumn<double>(
                name: "Bonus",
                table: "VacancySalaries",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "LowerWageLimitRubles",
                table: "VacancySalaries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpperWageLimitRubles",
                table: "VacancySalaries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "VacancyContacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Skype",
                table: "VacancyContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "VacancyContacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Formatted",
                table: "VacancyContactPhones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "VacancyContactPhones",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "VacancyTypeId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vacancies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedAt",
                table: "Vacancies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Vacancies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "AcceptKids",
                table: "Vacancies",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "AcceptHandicapped",
                table: "Vacancies",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "AcceptPensioner",
                table: "Vacancies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AcceptStudent",
                table: "Vacancies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Vacancies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RemoteInterview",
                table: "Vacancies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VacancyVisibilityTypeId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Specializations",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "Specializations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ProfessionalAreas",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "ProfessionalAreas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "Experiences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "Employments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "EducationLevels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromAvitoRu",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierParentFromZarplataRu",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromZarplataRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacancyVisibilityTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromAvitoRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyVisibilityTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacancyPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyPositions_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyPositions_Vacancies_VacancyId",
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
                value: "0e297676-e770-413c-afc6-30103d6ebda3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "6e53c990-4846-4c5f-851d-63cccdb2ee19");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "9fa854c3-59f4-49ba-ada7-c0e89be3ab70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fffc32c1-d15b-46ef-8abe-9f6afb005a17", "AQAAAAEAACcQAAAAEEZR1oCQjkrxQT4XqMYQsfCQJR4sITX7nKK6zmngT4wOzEGOSOREBFFMThsrxA45Xw==" });

            migrationBuilder.CreateIndex(
                name: "IX_VacancyContacts_AddressId",
                table: "VacancyContacts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_VacancyVisibilityTypeId",
                table: "Vacancies",
                column: "VacancyVisibilityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyPositions_PositionId",
                table: "VacancyPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyPositions_VacancyId",
                table: "VacancyPositions",
                column: "VacancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_VacancyTypes_VacancyTypeId",
                table: "Vacancies",
                column: "VacancyTypeId",
                principalTable: "VacancyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_VacancyVisibilityTypes_VacancyVisibilityTypeId",
                table: "Vacancies",
                column: "VacancyVisibilityTypeId",
                principalTable: "VacancyVisibilityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyContacts_Addresses_AddressId",
                table: "VacancyContacts",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_VacancyTypes_VacancyTypeId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_VacancyVisibilityTypes_VacancyVisibilityTypeId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_VacancyContacts_Addresses_AddressId",
                table: "VacancyContacts");

            migrationBuilder.DropTable(
                name: "VacancyPositions");

            migrationBuilder.DropTable(
                name: "VacancyVisibilityTypes");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_VacancyContacts_AddressId",
                table: "VacancyContacts");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_VacancyVisibilityTypeId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Bonus",
                table: "VacancySalaries");

            migrationBuilder.DropColumn(
                name: "LowerWageLimitRubles",
                table: "VacancySalaries");

            migrationBuilder.DropColumn(
                name: "UpperWageLimitRubles",
                table: "VacancySalaries");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "VacancyContacts");

            migrationBuilder.DropColumn(
                name: "Skype",
                table: "VacancyContacts");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "VacancyContacts");

            migrationBuilder.DropColumn(
                name: "Formatted",
                table: "VacancyContactPhones");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "VacancyContactPhones");

            migrationBuilder.DropColumn(
                name: "AcceptPensioner",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "AcceptStudent",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "RemoteInterview",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "VacancyVisibilityTypeId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "ProfessionalAreas");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "EducationLevels");

            migrationBuilder.DropColumn(
                name: "IdentifierFromAvitoRu",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "IdentifierParentFromZarplataRu",
                table: "Areas");

            migrationBuilder.AlterColumn<Guid>(
                name: "VacancyTypeId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedAt",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AcceptKids",
                table: "Vacancies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AcceptHandicapped",
                table: "Vacancies",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Specializations",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "ProfessionalAreas",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "71224bb1-89dd-4819-8c92-e7689568a2c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "f3ed2bd0-541e-4ff8-a5ed-845e941f6008");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "1d7945a7-3e1a-47a0-acf9-459b73777488");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2940ca63-f45d-4ca1-888c-719eee30753e", "AQAAAAEAACcQAAAAEIkf7OXpvzhKKvDaFBwRV9DqMESqLmTXl6sdLY3YtCZhaqa5LdPxZ/RLB8o+fKMAKg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_VacancyTypes_VacancyTypeId",
                table: "Vacancies",
                column: "VacancyTypeId",
                principalTable: "VacancyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
