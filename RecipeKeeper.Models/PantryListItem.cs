using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
    public class PantryListItem
    {
      
        public int PantryId { get; set; }
        public string IngredientName { get; set; }
        public bool InStock { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
    }
}
