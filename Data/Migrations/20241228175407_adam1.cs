﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class adam1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoppingCart_Id",
                table: "CartDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCart_Id",
                table: "CartDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
