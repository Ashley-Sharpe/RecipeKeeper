using RecipeKeeper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Models
{
    public class RecipesByIngredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public virtual ICollection<Recipe> ListOfRecipes {get;set;}
    }

}
