using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VantaTest.Migrations
{
    /// <inheritdoc />
    public partial class Update_Category2_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCategories_AppCategories_ParentId",
                table: "AppCategories");

            migrationBuilder.DropIndex(
                name: "IX_AppCategories_ParentId",
                table: "AppCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
