using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Migrations
{
    public partial class UpdateIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "B867520A-92DB-4658-BE39-84DA53A601C0", "8117d2fe-6c4e-4342-a8e3-826574033478", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "21F7B496-C675-4E8A-A34C-FC5EC0762FDB", 0, "043bbdff-79a0-441e-8ef4-72573e9e6257", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEIe27E0A/knjju3ha9itCPXYD8PGrnTW25g6Gq3/K+jOEELnyyutguBTVCXI3VqSyA==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "B867520A-92DB-4658-BE39-84DA53A601C0", "21F7B496-C675-4E8A-A34C-FC5EC0762FDB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "B867520A-92DB-4658-BE39-84DA53A601C0", "21F7B496-C675-4E8A-A34C-FC5EC0762FDB" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", "8db18148-ee58-4f1d-b2e0-f54f2cd93e95", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "4b558d94-9e58-446a-b274-37dca63491ce", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAECZqBFv/DNKtwMGJYR8M4tLAY71rS1Hwz8Ln65/54GHVWRAgkTDM+0qsRMLuqX30KA==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }
    }
}
