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
        public IEnumerable<IngredientListItem> GetIngredients() 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Ingredients
                    .Select(
                    e =>
                    new IngredientListItem
                    {
                        IngredientId = e.IngredientId,
                        IngredientName = e.IngredientName,
                        IngredientType = e.IngredientType
                    }
                    );


                    return query.ToArray();
            }
        }
        public IngredientDetail GetIngredientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Ingredients
                    .Single(e => e.IngredientId == id);
                return
                    new IngredientDetail
                    {
                        IngredientId = entity.IngredientId,
                        IngredientName = entity.IngredientName,
                        IngredientType = entity.IngredientType

                    };
            }
        }
        public IEnumerable<IngredientListItem> GetIngredientByIngredientType(string ingredientType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Ingredients
                    .Where(e => e.IngredientType == ingredientType)
                    .Select(e => new IngredientListItem
                    {
                        IngredientId = e.IngredientId,
                        IngredientName = e.IngredientName,
                        IngredientType = e.IngredientType
                    });
                return entity.ToArray();
                    
            }

        }
        public bool UpdateIngredient(IngredientEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Ingredients
                    .Single(e => e.IngredientId == model.IngredientId);
                entity.IngredientId = model.IngredientId;
                entity.IngredientName = model.IngredientName;
                entity.IngredientType = model.IngredientType;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteIngredient(int ingredientid)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Ingredients
                    .Single(e => e.IngredientId == ingredientid);
                ctx.Ingredients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
