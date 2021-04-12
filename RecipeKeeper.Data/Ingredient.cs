using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Data
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [ForeignKey("Pantry")]
        public int PantryId { get; set; }
        public virtual Pantry Pantry { get; set; }

        public string IngredientName { get; set; }
        
    }
}
