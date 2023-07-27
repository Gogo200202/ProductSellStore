using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSellStore.Data.Migrations
{
    public partial class orderNumberAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "09014c3e-72a5-47dd-8422-225dda59ea2e");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "33b84925-c6a0-47cc-bd9b-f98c02a15e2a", 0, null, "ec9f3acd-84e9-4acf-baa4-d83d76d8d4e6", "Admin@gmail.com", true, false, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAEAACcQAAAAEM3GM/vl/lWhX+93zs3UFmVM0FKSKNRR24Ep3gsvkTC8ldMS1rB35x6trzJTF5C/Hg==", "+111111111111", true, "7e601654-0fb6-4f72-8032-ee02add4385f", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33b84925-c6a0-47cc-bd9b-f98c02a15e2a");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "09014c3e-72a5-47dd-8422-225dda59ea2e", 0, null, "fb644a29-1b3d-4535-b43b-fa6060ff19f5", "Admin@gmail.com", true, false, null, "ADMIN@gmail.com", "ADMIN", "AQAAAAEAACcQAAAAEHTqoFOHzTrR8rOxZpVB0l1vRRWYZKyG9NxpFIUGYoLbpa43G6vcb7JaIA4rm1z2NQ==", "+111111111111", true, "993b55fc-7fea-43fd-b25f-833b0637c2a9", false, "Admin" });
        }
    }
}
