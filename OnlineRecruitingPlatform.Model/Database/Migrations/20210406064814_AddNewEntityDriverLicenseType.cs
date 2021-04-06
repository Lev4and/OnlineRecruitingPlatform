using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddNewEntityDriverLicenseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DriverLicenseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverLicenseTypes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "44381bef-38d2-4d60-9af0-fdf239a86e1f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "a286d41b-9cf2-4a2d-bf47-e0934612f834");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "9e8efe95-c084-421e-a20b-edfdf66e2d39");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "54b104b2-0a06-466c-ab69-fdd5ad353aec", "AQAAAAEAACcQAAAAEFQ5lFKaBxb/cDHliBa0NoUCR1RDqrrbQXPv/rR1aeCwFvF2cWeMaTCV00PJQjOKHQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DriverLicenseTypes");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "84c4fbf7-0f43-40d7-a498-9da7070c4b4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "6edcf379-0575-4585-90d4-88e8b099a5c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "d213d8b2-4175-4b93-89c7-190dd14aff9a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ef42e60-4eee-4b83-8cdc-d24488dffd38", "AQAAAAEAACcQAAAAEHuYJKXDz5uEwoCnYdWsYiacJmLMvbnckjmqOvimb6AoINs/VlDCr5mSevG11d8YCQ==" });
        }
    }
}
