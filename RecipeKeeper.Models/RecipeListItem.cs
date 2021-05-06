using RecipeKeeper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
    
    public class RecipeListItem
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string CuisineType { get; set; }
        public string RecipeType { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
        [Display(Name="Book Title")]
        public string BookName { get; set; }
        public int? PageNumber { get; set; }
    }
}
