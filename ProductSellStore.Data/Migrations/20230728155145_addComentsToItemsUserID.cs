using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSellStore.Data.Migrations
{
    public partial class addComentsToItemsUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ItemComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81482a5c-371d-4c42-a962-ccd78174a997");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ItemComments");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b86862c5-e39d-495c-b1db-c2bf925f495b", 0, null, "8ac49034-b921-4a62-9518-37a94c3d1707", "Admin@gmail.com", true, false, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAEAACcQAAAAELpItpZH8KyESLfxgnPNXgZO06k/GHWQ5lO5t7Im8sb2ffSFggbYujNwkLcCflyBGQ==", "+111111111111", true, "ce319661-f693-43d8-a46f-70ed5449503b", false, "Admin" });
        }
    }
}
