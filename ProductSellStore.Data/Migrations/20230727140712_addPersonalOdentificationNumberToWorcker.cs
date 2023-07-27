using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSellStore.Data.Migrations
{
    public partial class addPersonalOdentificationNumberToWorcker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "PersonalIdentificationNumber",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

         }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "831d8df8-e2de-4586-972d-e4b3ed7b2a73");

            migrationBuilder.DropColumn(
                name: "PersonalIdentificationNumber",
                table: "Workers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d9245adc-2cf0-4e33-84d3-7a9d451ec209", 0, null, "ef28a333-053c-4de7-be9a-76d6a137b3d8", "Admin@gmail.com", true, false, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAEAACcQAAAAEIOEm1/NfgZJd0fha0o0nZSs2E67ACKenHNEsZhbzZH53Z1mjuSzy26A26IOHoz8vg==", "+111111111111", true, "89032953-136d-44b4-984f-d1d6e42a0ae3", false, "Admin" });
        }
    }
}
