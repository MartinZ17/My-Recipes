using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class OriginalUrlRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoteImageUrl",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalUrl",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RemoteImageUrl",
                table: "Images");
        }
    }
}
