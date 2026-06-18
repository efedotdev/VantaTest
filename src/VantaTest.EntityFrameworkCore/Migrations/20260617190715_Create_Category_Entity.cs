using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VantaTest.Migrations
{
    /// <inheritdoc />
    public partial class Create_Category_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "AppFoods");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "AppFoods",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFoods_CategoryId",
                table: "AppFoods",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFoods_Category_CategoryId",
                table: "AppFoods",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFoods_Category_CategoryId",
                table: "AppFoods");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_AppFoods_CategoryId",
                table: "AppFoods");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AppFoods");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AppFoods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
