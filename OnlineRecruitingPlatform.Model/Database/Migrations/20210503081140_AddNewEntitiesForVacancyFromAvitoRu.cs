using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddNewEntitiesForVacancyFromAvitoRu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AgePreferenceId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PayPeriodId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PayoutFrequencyId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Piecework",
                table: "Vacancies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlaceOfWorkId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProfessionalAreaId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromAvitoRu",
                table: "ProfessionalAreas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgePreferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromAvitoRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgePreferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaidPeriods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromAvitoRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayoutFrequencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromAvitoRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutFrequencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlaceOfWorks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromAvitoRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOfWorks", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_AgePreferenceId",
                table: "Vacancies",
                column: "AgePreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_PayoutFrequencyId",
                table: "Vacancies",
                column: "PayoutFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_PayPeriodId",
                table: "Vacancies",
                column: "PayPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_PlaceOfWorkId",
                table: "Vacancies",
                column: "PlaceOfWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_ProfessionalAreaId",
                table: "Vacancies",
                column: "ProfessionalAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_AgePreferences_AgePreferenceId",
                table: "Vacancies",
                column: "AgePreferenceId",
                principalTable: "AgePreferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_PaidPeriods_PayPeriodId",
                table: "Vacancies",
                column: "PayPeriodId",
                principalTable: "PaidPeriods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_PayoutFrequencies_PayoutFrequencyId",
                table: "Vacancies",
                column: "PayoutFrequencyId",
                principalTable: "PayoutFrequencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_PlaceOfWorks_PlaceOfWorkId",
                table: "Vacancies",
                column: "PlaceOfWorkId",
                principalTable: "PlaceOfWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_ProfessionalAreas_ProfessionalAreaId",
                table: "Vacancies",
                column: "ProfessionalAreaId",
                principalTable: "ProfessionalAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_AgePreferences_AgePreferenceId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_PaidPeriods_PayPeriodId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_PayoutFrequencies_PayoutFrequencyId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_PlaceOfWorks_PlaceOfWorkId",
                table: "Vacancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_ProfessionalAreas_ProfessionalAreaId",
                table: "Vacancies");

            migrationBuilder.DropTable(
                name: "AgePreferences");

            migrationBuilder.DropTable(
                name: "PaidPeriods");

            migrationBuilder.DropTable(
                name: "PayoutFrequencies");

            migrationBuilder.DropTable(
                name: "PlaceOfWorks");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_AgePreferenceId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_PayoutFrequencyId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_PayPeriodId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_PlaceOfWorkId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_ProfessionalAreaId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "AgePreferenceId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "PayPeriodId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "PayoutFrequencyId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Piecework",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "PlaceOfWorkId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "ProfessionalAreaId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "IdentifierFromAvitoRu",
                table: "ProfessionalAreas");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "d3be0ea8-4aeb-47a9-8bb8-374b9627eb3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "0707d6c7-f803-4016-aa00-644be4e9559a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "4464257e-e21e-4c92-bda1-2a9f17d77b56");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "04e477bf-9f2c-455a-b6b7-495f88736587", "AQAAAAEAACcQAAAAEIIUxaTPSPqQ6MEdHIDyDSGWHCcya4OIiBLJronN8vyczGV1xDf4NNKAUi+p5pwNjA==" });
        }
    }
}
