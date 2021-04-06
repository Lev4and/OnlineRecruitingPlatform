using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddNewEntityEmployerActiveVacanciesOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployerActiveVacanciesOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerActiveVacanciesOrders", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "2890a0c7-89a6-415c-a98a-203519f69172");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "07e7cf1b-c286-42dd-a678-54cb52f9bb1c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "70311f83-6a76-4ac2-96cc-208af1301363");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0923a690-f8e6-4fff-b5bf-f8584dc85a20", "AQAAAAEAACcQAAAAEDtDprURhkl6T7LwFhAoXYIHREmtFXo6PqW44/5QsZuacWPUfc5WWERvHSDcedBtMw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployerActiveVacanciesOrders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "06e5df81-578d-4f23-a5f2-fffb5808a856");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "4cd62d45-21ec-4a11-b97c-4ad32f168926");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "0b9658e4-26e9-4868-8e3b-5acce9c43342");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87edbb2c-29f3-410a-bcd4-c991a8e91533", "AQAAAAEAACcQAAAAEARpPw8qd0v2olTd+9olEHyKRRM+jgesx4RFVW+lwfvbUANqKOvRt3BDUCaGP05T/Q==" });
        }
    }
}
