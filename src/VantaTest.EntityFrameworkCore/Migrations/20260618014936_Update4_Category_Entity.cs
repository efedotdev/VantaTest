using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VantaTest.Migrations
{
    /// <inheritdoc />
    public partial class Update4_Category_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "AppCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "AppCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppCategories_ParentId",
                table: "AppCategories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCategories_AppCategories_ParentId",
                table: "AppCategories",
                column: "ParentId",
                principalTable: "AppCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCategories_AppCategories_ParentId",
                table: "AppCategories");

            migrationBuilder.DropIndex(
                name: "IX_AppCategories_ParentId",
                table: "AppCategories");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AppCategories");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AppCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
