﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductSellStore.Data.Migrations
{
    public partial class keyitemuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemsUsers_ItemId",
                table: "ItemsUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsUsers",
                table: "ItemsUsers",
                columns: new[] { "ItemId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsUsers",
                table: "ItemsUsers");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsUsers_ItemId",
                table: "ItemsUsers",
                column: "ItemId");
        }
    }
}
