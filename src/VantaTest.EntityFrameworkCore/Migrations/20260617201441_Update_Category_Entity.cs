using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VantaTest.Migrations
{
    /// <inheritdoc />
    public partial class Update_Category_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFoods_Category_CategoryId",
                table: "AppFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "AppCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCategories",
                table: "AppCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFoods_AppCategories_CategoryId",
                table: "AppFoods",
                column: "CategoryId",
                principalTable: "AppCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppFoods_AppCategories_CategoryId",
                table: "AppFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCategories",
                table: "AppCategories");

            migrationBuilder.RenameTable(
                name: "AppCategories",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppFoods_Category_CategoryId",
                table: "AppFoods",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
