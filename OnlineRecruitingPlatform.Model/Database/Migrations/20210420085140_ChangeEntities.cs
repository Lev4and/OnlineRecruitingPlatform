using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class ChangeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "LanguageLevels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "Genders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "Employments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "EmployerTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "EmployerRelations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "EmployerArchivedVacanciesOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "EmployerActiveVacanciesOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "EducationLevels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "DriverLicenseTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "BusinessTripReadinessTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "eeef7aff-ba33-4749-bc15-069a182b8e24");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "3c27925d-d7de-44ac-856d-8da17a693c66");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "3fa95a94-375f-4c7d-a4ab-769a3b157859");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1068965d-9134-4274-9791-6de531bb630d", "AQAAAAEAACcQAAAAEDvvDZs9o6JrLrysjgb5psbipe6W63ck8g1C6Rpsc9wel9H7+RVrrlqWNx32Y/vKZQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "LanguageLevels");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "Employments");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "EmployerTypes");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "EmployerRelations");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "EmployerArchivedVacanciesOrders");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "EmployerActiveVacanciesOrders");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "EducationLevels");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "DriverLicenseTypes");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "BusinessTripReadinessTypes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "75808e3b-0d73-4656-928e-cd79dbb3df0b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "aca55a80-65a7-436d-a54d-50ceb3a7f84e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "141f765e-1c08-4090-8fe7-4b4a4a8cb41e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b49b1eb3-d376-4ef5-8a4b-66a96ee05f87", "AQAAAAEAACcQAAAAECYddqq6/UoS1NjxOjTOHUDP/emhIX1xcmRh1xt9cmZZ80yufFFP3W8am9n1yVrSwQ==" });
        }
    }
}
