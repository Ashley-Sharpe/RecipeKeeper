using RecipeKeeper.Data;
using RecipeKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeKeeper.service
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
                BookId = model.BookId,
                CuisineType = model.CuisineType,
                RecipeType = model.RecipeType,
                PageNumber = model.PageNumber
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }
        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var ctx = new ApplicationDbContext())
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
                        Ingredients = e.Ingredients,
                        BookName = e.Book.BookName,
                        PageNumber = e.PageNumber
                    }
                    );
                return query.ToArray();
            }

        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Recipes
                    .Single(e => e.RecipeId == id && e.OwnerId == _userId);


                return
                new RecipeDetail
                {
                    RecipeId = entity.RecipeId,
                    RecipeName = entity.RecipeName,
                    RecipeType = entity.RecipeType,
                    BookName = entity.Book.BookName,
                    Author = entity.Book.Author,
                    PageNumber = entity.PageNumber,
                    Ingredients = entity.Ingredients,
                    CuisineType = entity.CuisineType,
                    BookId = entity.BookId
                };

            }
        }
        public bool UpdateRecipe(RecipeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                  .Recipes
                  .Single(e => e.OwnerId == _userId && e.RecipeId == model.RecipeId);
                entity.RecipeName = model.RecipeName;
                entity.RecipeType = model.RecipeType;
                entity.PageNumber = model.PageNumber;
                entity.CuisineType = model.CuisineType;

                return ctx.SaveChanges() == 1;
            }
        

        }
        //Entity.ingredients needs to be breakpointed and if it doesn't work then call a method (get ingredients by recipeId)

        // Update Recipe with ingredients (follows edit logic ) this is NOT DONE YET will go above comment
    }
}















