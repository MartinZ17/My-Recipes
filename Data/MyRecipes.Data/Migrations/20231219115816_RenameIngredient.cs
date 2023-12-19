using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngrediantId",
                table: "RecipeIngredients");

            migrationBuilder.RenameColumn(
                name: "IngrediantId",
                table: "RecipeIngredients",
                newName: "IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_IngrediantId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngredientId",
                table: "RecipeIngredients");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "RecipeIngredients",
                newName: "IngrediantId");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                newName: "IX_RecipeIngredients_IngrediantId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Ingredients_IngrediantId",
                table: "RecipeIngredients",
                column: "IngrediantId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
