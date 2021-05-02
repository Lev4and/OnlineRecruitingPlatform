using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineRecruitingPlatform.Model.Database.Migrations
{
    public partial class AddMissingEntitiesRelatedWithVacancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Street_StreetId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Street_StreetId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Street_Areas_Aoguid",
                table: "Street");

            migrationBuilder.DropForeignKey(
                name: "FK_VacancyInformation_VacancyBillingType_VacancyBillingTypeId",
                table: "VacancyInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VacancyBillingType",
                table: "VacancyBillingType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Street",
                table: "Street");

            migrationBuilder.RenameTable(
                name: "VacancyBillingType",
                newName: "VacancyBillingTypes");

            migrationBuilder.RenameTable(
                name: "Street",
                newName: "Streets");

            migrationBuilder.RenameIndex(
                name: "IX_Street_Aoguid",
                table: "Streets",
                newName: "IX_Streets_Aoguid");

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromAvitoRu",
                table: "Vacancies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdentifierFromZarplataRu",
                table: "Vacancies",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VacancyBillingTypes",
                table: "VacancyBillingTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Streets",
                table: "Streets",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "0a035b43-4c46-40ac-983b-1c972bbaf663");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "9191e926-a919-459b-af4a-8818be48c319");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "dd65f55f-80aa-4f57-9abb-573de201e374");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bebb7b86-ca42-45f8-bff1-c37a24ad3d99", "AQAAAAEAACcQAAAAENGtl4SIpX4rBxSepPVpMrN1v8AjplvzBWo7nz0gR8ZPLxQNk3NpydA0yLn2S8ymFA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Streets_StreetId",
                table: "Buildings",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_Areas_Aoguid",
                table: "Streets",
                column: "Aoguid",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyInformation_VacancyBillingTypes_VacancyBillingTypeId",
                table: "VacancyInformation",
                column: "VacancyBillingTypeId",
                principalTable: "VacancyBillingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Streets_StreetId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_Areas_Aoguid",
                table: "Streets");

            migrationBuilder.DropForeignKey(
                name: "FK_VacancyInformation_VacancyBillingTypes_VacancyBillingTypeId",
                table: "VacancyInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VacancyBillingTypes",
                table: "VacancyBillingTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Streets",
                table: "Streets");

            migrationBuilder.DropColumn(
                name: "IdentifierFromAvitoRu",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "IdentifierFromZarplataRu",
                table: "Vacancies");

            migrationBuilder.RenameTable(
                name: "VacancyBillingTypes",
                newName: "VacancyBillingType");

            migrationBuilder.RenameTable(
                name: "Streets",
                newName: "Street");

            migrationBuilder.RenameIndex(
                name: "IX_Streets_Aoguid",
                table: "Street",
                newName: "IX_Street_Aoguid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VacancyBillingType",
                table: "VacancyBillingType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Street",
                table: "Street",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2AABA004-1052-4F53-9EB3-18FA85386AD5",
                column: "ConcurrencyStamp",
                value: "4f31f924-3bf6-4739-a44b-1700cbd75f8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8F525C31-6BCF-460F-86A3-BD51FA76F382",
                column: "ConcurrencyStamp",
                value: "8d326e9e-3009-469c-841a-06cc81caddc2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "B867520A-92DB-4658-BE39-84DA53A601C0",
                column: "ConcurrencyStamp",
                value: "f61507b7-6236-4ba1-98ef-4e62b9721a3a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44414274-0d37-40c9-975a-5afe879725e0", "AQAAAAEAACcQAAAAEAWVW1RPIbBxPUzbsTo7eWqRdhqo5JZfhVzrBTiKR5NKrPGF63/2HKH/0S7cepUOyQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Street_StreetId",
                table: "Addresses",
                column: "StreetId",
                principalTable: "Street",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Street_StreetId",
                table: "Buildings",
                column: "StreetId",
                principalTable: "Street",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Street_Areas_Aoguid",
                table: "Street",
                column: "Aoguid",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VacancyInformation_VacancyBillingType_VacancyBillingTypeId",
                table: "VacancyInformation",
                column: "VacancyBillingTypeId",
                principalTable: "VacancyBillingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
