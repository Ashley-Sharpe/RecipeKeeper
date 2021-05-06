using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Data
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [Required]
        public string IngredientName { get; set; }
        public string IngredientType { get; set; }
        //public List<Ingredient> Ingredients { get; set; }
        //public int Quantity { get; set; }
        //public List<Recipe> Recipes {get;set;}

        public virtual ICollection<Recipe> ListOfRecipes { get; set; }
        public Ingredient()
        {
            ListOfRecipes = new HashSet<Recipe>();
        }
     
    }
}
