using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
    
    public class RecipeListItem
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string Ingredients { get; set; }
        public string BookName { get; set; }
        public int? PageNumber { get; set; }
    }
}
