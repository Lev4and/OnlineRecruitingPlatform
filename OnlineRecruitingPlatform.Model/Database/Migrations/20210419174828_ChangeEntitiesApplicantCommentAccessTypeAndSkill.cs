using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class ChangeEntitiesApplicantCommentAccessTypeAndSkill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "Skills");

            migrationBuilder.AddColumn<string>(
                name: "IdentifierFromHeadHunter",
                table: "ApplicantCommentAccessTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "f4d28819-25c5-46e8-8e15-65963ff004a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "02428804-16ec-48f0-be51-c46990d2f4ac");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "45c81660-6048-4f02-a7e2-885382c89ef2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5b4082c-a377-4b9a-9a15-27000856dcbf", "AQAAAAEAACcQAAAAEBvPlFyD8oFeedyHswqd6IeWhSLY0JXqXPGCPxhE8NWRM262mbVA/vLMqjAvoKnoAg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentifierFromHeadHunter",
                table: "ApplicantCommentAccessTypes");

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "5e783eb3-4bc7-4917-941e-7c0702a3d735");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "b4a2aece-0788-40b7-8b91-406f6c2d000c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "2daa187d-fddd-431a-aac7-bfcf93aa1ae3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5877c93-972a-441c-a595-bad6073f005e", "AQAAAAEAACcQAAAAEKLXeO2cKdgba8ZgXlln+9RlHaQIOTgU9dUOo11zmggn8kIYBHm7cYnU4RbAkWempw==" });
        }
    }
}
