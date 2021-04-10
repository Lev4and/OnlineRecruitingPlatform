using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddNewEntitySkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "781d22d6-5187-463d-b0a5-42cfccba82ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "eb8ffddb-18f9-4460-a9ed-0ced38870559");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "835299e8-113f-4838-aa16-6fdc944501e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee30aaf8-dbb5-4d59-be5a-fd47e6862bc8", "AQAAAAEAACcQAAAAEL5dnuDqwNALUouyId3nEK9FmwveWVvdghs3v3mrNN/X3N8QKWCdbk/7ewN0wdWUgw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "0668fd25-81d8-4de3-9694-97c886760881");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "a739583b-2a75-47b5-be70-8aac4edb88fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "8523d2d7-ed1c-407a-a5e4-e36a7b816853");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e8ef423f-0860-4c54-a9e8-5c09cae7309a", "AQAAAAEAACcQAAAAEBbwiIEDIHDowsdhxHbSlpSb8zrZ8ibG0bMOfZUYg1+uFD4nTU9woeEjoqpIoAaEbA==" });
        }
    }
}
