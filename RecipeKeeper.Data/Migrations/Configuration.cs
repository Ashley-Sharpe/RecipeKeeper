namespace RecipeKeeper.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipeKeeper.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RecipeKeeper.Data.ApplicationDbContext";
        }

        protected override void Seed(RecipeKeeper.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Ingredients.AddOrUpdate(i => i.IngredientId,



                new Ingredient { IngredientId = 1, IngredientName = "Apple", IngredientType = "Fruit" },
            new Ingredient { IngredientId = 2, IngredientName = "Salt", IngredientType = "Seasoning/Spice" },
            new Ingredient { IngredientId = 3, IngredientName = "Peanut Butter", IngredientType = "Nuts" },
            new Ingredient { IngredientId = 4, IngredientName = "Bread", IngredientType = "Grain" },
            new Ingredient { IngredientId = 5, IngredientName = "Strawberry", IngredientType = "Fruit" },
            new Ingredient { IngredientId = 6, IngredientName = "Granulated Sugar", IngredientType = "Sweetener" },
            new Ingredient { IngredientId = 7, IngredientName = "Light Brown Sugar", IngredientType = "Sweetener" },
            new Ingredient { IngredientId = 8, IngredientName = "Dark Brown Sugar", IngredientType = "Sweetener" },
            new Ingredient { IngredientId = 9, IngredientName = "Honey", IngredientType = "Sweetener" },
            new Ingredient { IngredientId = 10, IngredientName = "Milk", IngredientType = "Dairy" },
            new Ingredient { IngredientId = 11, IngredientName = "Plain Yogurt", IngredientType = "Dairy" },
            new Ingredient { IngredientId = 12, IngredientName = "Cauliflower", IngredientType = "Vegetable" },
            new Ingredient { IngredientId = 13, IngredientName = "Green Beans", IngredientType = "Vegetable" },
            new Ingredient { IngredientId = 14, IngredientName = "Butter", IngredientType = "Dairy" },
            new Ingredient { IngredientId = 15, IngredientName = "Pepper", IngredientType = "Seasoning/Spice" }
                );



        }
    }
}
