namespace MyRecipes.Data.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public int IngrediantId { get; set; }

        public virtual Ingredient Ingrediant { get; set; }

        public string Quantity { get; set; }
    }
}
