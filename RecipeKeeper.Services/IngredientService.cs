using RecipeKeeper.Data;
using RecipeKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.service
{
    public class IngredientService
    {
        public bool CreateIngredient(IngredientCreate model)
        {
            var entity =
                  new Ingredient()
                  {
                      IngredientName = model.IngredientName,
                      IngredientType = model.IngredientType

                  };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<IngredientListItem> GetIngredients() //take ingredient that is being searched for - how to take user input to return recipes
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Ingredients
                    .Select(
                    e =>
                    new IngredientListItem
                    {
                        IngredientName = e.IngredientName,
                        IngredientType = e.IngredientType
                    }
                    );


                    return query.ToArray();
            }
        }
    }
}
