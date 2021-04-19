using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
    public class PantryEdit
    {
      
        public int PantryId { get; set; }
        public string IngredientName { get; set; }
        public bool InStock { get; set; }
        public string Location { get; set; }
        public string Quantity { get; set; }
    }
}
