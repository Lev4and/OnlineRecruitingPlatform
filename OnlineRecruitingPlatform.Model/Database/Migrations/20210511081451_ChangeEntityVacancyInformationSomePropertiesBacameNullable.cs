using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class ChangeEntityVacancyInformationSomePropertiesBacameNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacancyInformation_VacancyBillingTypes_VacancyBillingTypeId",
                table: "VacancyInformation");

            migrationBuilder.AlterColumn<Guid>(
                name: "VacancyBillingTypeId",
                table: "VacancyInformation",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "bcb65553-729f-4259-bb55-d1b6e69e13b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "e9dd94cd-c1d4-46cf-a7a4-b8d2b6942815");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "fc54b356-3c5a-4cfa-9a9a-bd9efc4f7936");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5f6a1284-6df0-4e23-a65c-e1ccefaab399", "AQAAAAEAACcQAAAAEJpZSD2ORkNWC2u9wiPmzdcCsMK6AmU9vriB0hiSUJskoXXbkEiCtl92NYXl0qX6ZQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyInformation_VacancyBillingTypes_VacancyBillingTypeId",
                table: "VacancyInformation",
                column: "VacancyBillingTypeId",
                principalTable: "VacancyBillingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacancyInformation_VacancyBillingTypes_VacancyBillingTypeId",
                table: "VacancyInformation");

            migrationBuilder.AlterColumn<Guid>(
                name: "VacancyBillingTypeId",
                table: "VacancyInformation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "43e80e8c-dc60-44b7-8808-91c01fae3074");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "f839a374-afcf-4fb8-9e09-ff50e8b5e53f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "6af9bb84-fdcb-495b-98fc-274f097f6b32");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a296606-d1ba-4eec-8c3e-f69c54578f5e", "AQAAAAEAACcQAAAAEHE/aX93dyLrMjY3W6LVBhWJMIq6ic+u+/FHooV8Bt4AMjGOVhqoJpLtaMipaMQ2DA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyInformation_VacancyBillingTypes_VacancyBillingTypeId",
                table: "VacancyInformation",
                column: "VacancyBillingTypeId",
                principalTable: "VacancyBillingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
