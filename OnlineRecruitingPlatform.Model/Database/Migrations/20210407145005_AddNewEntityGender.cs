using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddNewEntityGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "361684e3-b93f-4e7b-9488-f6fecc5acbf8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "20f057ff-1bce-45b8-b481-e4dda64b1b12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "8a6a2567-6667-42f9-b667-a1f141dda2d4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f59d9175-f625-423d-80a7-bacc2422d8aa", "AQAAAAEAACcQAAAAEI9cSVejLxTA3mjhcGQf72BEkPzRzptjP+t74RqPyon2AOS9pio+EHldimlcQAa+QA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "155759ca-55af-4a8c-a530-c46c365aa4e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "f76f60a7-57c0-43f4-9ff6-7165b43af50c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "79693bb9-0970-42e3-a265-13d819a56af1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "33e4ec59-fc0d-4031-af41-f41c24cca741", "AQAAAAEAACcQAAAAEC9YCiTXmzzdJ32cpsSe+LQErNlMXyvR6AvwVh3BlwG4mfgFgL35oHzOLIzc+YuqEA==" });
        }
    }
}
