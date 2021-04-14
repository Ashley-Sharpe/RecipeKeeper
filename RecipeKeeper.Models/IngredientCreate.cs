using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
    public class IngredientCreate
    {
        [Required]
        public string IngredientName { get; set; }
        
    }
}
