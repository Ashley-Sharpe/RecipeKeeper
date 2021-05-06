using RecipeKeeper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RecipeKeeper.Models
{
    public class RecipeCreate
    {
        [Required]
        public string RecipeName { get; set; }
        public int IngredientId { get; set; }
        public int IngredientName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
      
        public int? PageNumber { get; set; }
        
        [Display(Name= "Cooking or Baking recipe?")]
        public string RecipeType { get; set; }
        
        public string CuisineType { get; set; }
        
        public int BookId { get; set; }
    }
}
