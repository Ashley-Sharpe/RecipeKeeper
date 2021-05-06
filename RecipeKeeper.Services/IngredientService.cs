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
        public RecipesByIngredient GetRecipesByIngredient(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Ingredients
                    .Single(e => e.IngredientId == id);
                return
                    new RecipesByIngredient
                    {
                        IngredientId = entity.IngredientId,
                        IngredientName = entity.IngredientName,
                        ListOfRecipes = entity.ListOfRecipes

                    };
            }
        }
                public bool CreateIngredient(IngredientCreate model)
        {
            var entity = new Ingredient()
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

        public IEnumerable<Ingredient> GetIngredientList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Ingredients.ToList();
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
                // access the ingredients for the specific recipe 2. For each loop it (to display the ingredient list item) 
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
            using (var ctx = new ApplicationDbContext())
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
            using (var ctx = new ApplicationDbContext())
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
