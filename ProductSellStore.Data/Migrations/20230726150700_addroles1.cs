using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSellStore.Data.Migrations
{
    public partial class addroles1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b3ba4b5e-e44a-4f65-9a37-fe9694ff72bd");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "09014c3e-72a5-47dd-8422-225dda59ea2e", 0, null, "fb644a29-1b3d-4535-b43b-fa6060ff19f5", "Admin@gmail.com", true, false, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAEAACcQAAAAEHTqoFOHzTrR8rOxZpVB0l1vRRWYZKyG9NxpFIUGYoLbpa43G6vcb7JaIA4rm1z2NQ==", "+111111111111", true, "993b55fc-7fea-43fd-b25f-833b0637c2a9", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09014c3e-72a5-47dd-8422-225dda59ea2e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3ba4b5e-e44a-4f65-9a37-fe9694ff72bd", 0, null, "367628c0-e67d-497e-838f-2155500841a6", "Admin@gmail.com", false, false, null, null, null, null, null, false, "05db85a7-8bef-46e8-93fc-ad9d74199f3f", false, "Admin" });
        }
    }
}
