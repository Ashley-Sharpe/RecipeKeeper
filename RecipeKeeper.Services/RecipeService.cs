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
                //ListOfIngredients = model.Ingredients.Add(),
                BookId = model.BookId,
                CuisineType = model.CuisineType,
                RecipeType = model.RecipeType,
                PageNumber = model.PageNumber
            };
            using (var ctx = new ApplicationDbContext())
            {
                var oneIng = ctx.Ingredients.Single(x => x.IngredientId == model.IngredientId);
                entity.ListOfIngredients.Add(oneIng);
                ctx.Recipes.Add(entity);
                return ctx.SaveChanges() > 0;
            }
            //entity.Ingredient.Add(model.ingredient)
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
                            Ingredients = e.ListOfIngredients,
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
                        Ingredients = entity.ListOfIngredients.ToList(),
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

            public bool UpdateRecipeWithIngredients(RecipeEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var recipe = ctx
                        .Recipes
                        .Single(e => e.OwnerId == _userId && e.RecipeId == model.RecipeId);
                    var ingredient = ctx
                    .Ingredients
                    .Single(e => e.IngredientId == model.IngredientId);
                recipe.ListOfIngredients.Add(ingredient);
                    
                    return ctx.SaveChanges() == 1;
                }
            }
            public bool DeleteRecipe(int recipeid)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx
                        .Recipes
                        .Single(e => e.RecipeId == recipeid && e.OwnerId == _userId);
                    ctx.Recipes.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            
        }
    }
















