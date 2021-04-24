using RecipeKeeper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
    public class RecipeEdit
    {
        
        public int RecipeId { get; set; }
        
        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public string BookName { get; set; }
        public int? PageNumber { get; set; }
        
        [Display(Description = "Cooking or Baking recipe.")]
        public string RecipeType { get; set; }
        
        public string CuisineType { get; set; }

    }
}

