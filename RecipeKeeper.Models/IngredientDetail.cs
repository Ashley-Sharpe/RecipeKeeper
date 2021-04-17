using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
    public class IngredientDetail
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        [Display(Name="Type of Ingredient")]
        public string IngredientType { get; set; }
    }
}
