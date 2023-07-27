using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSellStore.Data.Migrations
{
    public partial class addPhoneNumberInOred : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33b84925-c6a0-47cc-bd9b-f98c02a15e2a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d9245adc-2cf0-4e33-84d3-7a9d451ec209", 0, null, "ef28a333-053c-4de7-be9a-76d6a137b3d8", "Admin@gmail.com", true, false, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAEAACcQAAAAEIOEm1/NfgZJd0fha0o0nZSs2E67ACKenHNEsZhbzZH53Z1mjuSzy26A26IOHoz8vg==", "+111111111111", true, "89032953-136d-44b4-984f-d1d6e42a0ae3", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d9245adc-2cf0-4e33-84d3-7a9d451ec209");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "33b84925-c6a0-47cc-bd9b-f98c02a15e2a", 0, null, "ec9f3acd-84e9-4acf-baa4-d83d76d8d4e6", "Admin@gmail.com", true, false, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAEAACcQAAAAEM3GM/vl/lWhX+93zs3UFmVM0FKSKNRR24Ep3gsvkTC8ldMS1rB35x6trzJTF5C/Hg==", "+111111111111", true, "7e601654-0fb6-4f72-8032-ee02add4385f", false, "Admin" });
        }
    }
}
