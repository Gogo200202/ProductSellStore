using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSellStore.Data.Migrations
{
    public partial class removeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

         }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ee5978d-ba2b-40a8-90a7-91435e7076b5");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "918bdd89-20eb-4a63-9c25-54a280a9fdc3", 0, null, "44a14ccc-bca1-4c71-b787-e8341136cab7", "Admin@gmail.com", true, false, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAEAACcQAAAAEEGteLTsFSe/6pNj/UeDQCFKlg8FD94O7f0fUxAi7HQqiupSWPWSf3lipyF2zO3+qw==", "+111111111111", true, "f864630e-d892-4289-956b-928327ee6b6b", false, "Admin" });
        }
    }
}
