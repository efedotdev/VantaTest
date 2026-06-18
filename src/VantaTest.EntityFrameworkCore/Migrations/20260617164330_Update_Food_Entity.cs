using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VantaTest.Migrations
{
    /// <inheritdoc />
    public partial class Update_Food_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodKind",
                table: "AppFoods",
                newName: "Type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "AppFoods",
                newName: "FoodKind");
        }
    }
}
