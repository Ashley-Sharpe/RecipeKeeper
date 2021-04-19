using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
   public class PantryCreate
    {
        [Required]
        [MaxLength(100)]
        public string IngredientName { get; set; }
        [Required]
        public bool InStock { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        [Required]
         public string Quantity { get; set; }
    }
}
