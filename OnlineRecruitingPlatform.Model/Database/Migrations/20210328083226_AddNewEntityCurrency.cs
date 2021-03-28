using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddNewEntityCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "e7bff0f0-03cf-4a3c-8757-a046cc470ced");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "62d10d77-6d6c-4544-9db3-1ceb02e065a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "798e0c0a-50c4-434a-b5f1-ad549d034a96");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e64de2ab-f227-49cc-b16e-712f892a295a", "AQAAAAEAACcQAAAAEK0fY8yg1Fec9yivcD3aGmvx9ncg/g7a8pfut78J0B3pbHuM5wYeBfrERWsINw49MQ==" });
        }
    }
}
