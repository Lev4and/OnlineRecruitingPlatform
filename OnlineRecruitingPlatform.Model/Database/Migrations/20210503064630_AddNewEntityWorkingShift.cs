using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddNewEntityWorkingShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "VacancyInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "WorkingShiftId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromAvitoRu",
                table: "Schedules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromAvitoRu",
                table: "Experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkingShifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentifierFromAvitoRu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingShifts", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_WorkingShiftId",
                table: "Vacancies",
                column: "WorkingShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_WorkingShifts_WorkingShiftId",
                table: "Vacancies",
                column: "WorkingShiftId",
                principalTable: "WorkingShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_WorkingShifts_WorkingShiftId",
                table: "Vacancies");

            migrationBuilder.DropTable(
                name: "WorkingShifts");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_WorkingShiftId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "VacancyInformation");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "WorkingShiftId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "IdentifierFromAvitoRu",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "IdentifierFromAvitoRu",
                table: "Experiences");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "67713619-b3bc-442a-9a8d-6b199ee475ba");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "cbddd8f4-abf1-4592-b693-09ebbd24131e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "e7217d2e-c563-45fa-a804-5bdf6ff41c45");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3355bd50-ca39-4943-be2a-aaec2ab3fce6", "AQAAAAEAACcQAAAAEP8OFibo2p6SNMJ4aSCBz7kLDH/YJB9R/OqeCPyNdPoN4vB/b9Cx1reyfWmDWx4Tzw==" });
        }
    }
}
