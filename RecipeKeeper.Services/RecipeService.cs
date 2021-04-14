using RecipeKeeper.Data;
using RecipeKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public RecipeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipe(RecipeCreate model)
        {
            var entity = new Recipe()
            {
                OwnerId = _userId,
                RecipeName = model.RecipeName,
                Ingredients = model.Ingredients,
                BookName = model.BookName,
                CuisineType = model.CuisineType,
                RecipeType = model.RecipeType,
                PageNumber = model.PageNumber,
                AuthorName = model.AuthorName,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }
        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Recipes
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                    e =>
                    new RecipeListItem
                    {
                        RecipeId = e.RecipeId,
                        RecipeName = e.RecipeName,
                        Ingredients = e.Ingredients
                    }
                    );
                return query.ToArray();
            }
        }

    }
}
