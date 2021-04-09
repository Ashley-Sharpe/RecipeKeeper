using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Data
{
    public class Pantry
    {
        [ForeignKey(nameof(Ingredient))]
        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public string IngredientName { get; set; }
        [Required]
        public bool InStock { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [MaxLength(100)]
        public int Quantity { get; set; }
    }
}
