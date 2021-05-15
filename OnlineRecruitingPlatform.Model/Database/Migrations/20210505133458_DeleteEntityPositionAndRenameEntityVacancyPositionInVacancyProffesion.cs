using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class DeleteEntityPositionAndRenameEntityVacancyPositionInVacancyProffesion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacancyPositions");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromZarplataRu",
                table: "Professions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VacancyProfessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacancyProfessions");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "Professions");

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifierFromZarplataRu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacancyPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacancyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "IX_VacancyPositions_PositionId",
                table: "VacancyPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyPositions_VacancyId",
                table: "VacancyPositions",
                column: "VacancyId");
        }
    }
}
