using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class ChangeEntityVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Areas_AreaId",
                table: "Vacancies");

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaId",
                table: "Vacancies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "4e052701-4d2f-4884-ae93-b3fb18848f54");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "00aa0f6a-71bd-4b08-926f-76de540501c3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "81cf7a06-e88e-4e50-9592-54d9360b8dc8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5bcc570b-1de6-427d-9ea5-4f78e1941345", "AQAAAAEAACcQAAAAEMBeFg55hEYlHSjt0WbAlSVWAGUOM07y3sWhogUsmd7EJBPpRki0dx2QRp4NMhisow==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Areas_AreaId",
                table: "Vacancies",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_Areas_AreaId",
                table: "Vacancies");

            migrationBuilder.AlterColumn<Guid>(
                name: "AreaId",
                table: "Vacancies",
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
                value: "ce3e94dd-18e1-4420-b4bc-8b29dcdd2ee8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "4a09a6cd-889a-4216-bc0b-13c2a262503d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "8d0fb7b5-8eea-494c-8504-9a8e06d5708d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4f0344f5-2db3-47de-a4aa-9d43571eea98", "AQAAAAEAACcQAAAAENaM81QT8I1vBaRzcbrUFn4YEPMF3LXBBetYAZunQKsNr8DavVhHXCKP5jwEiktLdA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_Areas_AreaId",
                table: "Vacancies",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
