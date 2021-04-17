namespace RecipeKeeper.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipeKeeper.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RecipeKeeper.Data.ApplicationDbContext context)
        {
            //This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.E.g.

       
        //    context.Authors.AddOrUpdate(x => x.Id,
        //new Author() { Id = 1, Name = "Jane Austen" },
        //new Author() { Id = 2, Name = "Charles Dickens" },
        //new Author() { Id = 3, Name = "Miguel de Cervantes" }
        //);
            context.Ingredients.AddOrUpdate(i => i.IngredientId,
                new Ingredient() { IngredientId = 1, IngredientName = "Chicken", IngredientType = "Meat" },
                new Ingredient() { IngredientId = 2, IngredientName = "All Purpose Flour", IngredientType = "Gluten" },
                new Ingredient() { IngredientId = 3, IngredientName = "Egg", IngredientType = "Dairy" },
                new Ingredient() { IngredientId = 4, IngredientName = "Peanut Butter", IngredientType = "Nuts" },
                new Ingredient() { IngredientId = 5, IngredientName = "Ground Beef", IngredientType = "Meat" },
                new Ingredient() { IngredientId = 6, IngredientName = "Baking Powder", IngredientType = "N/A" },
                new Ingredient() { IngredientId = 7, IngredientName = "Baking Soda", IngredientType = "N/A" },
                new Ingredient() { IngredientId = 8, IngredientName = "Milk", IngredientType = "Dairy" },
                new Ingredient() { IngredientId = 9, IngredientName = "Chocolate Chips", IngredientType = "Sweets" },
                new Ingredient() { IngredientId = 10, IngredientName = "Granulated Sugar", IngredientType = "Sweets" },
                new Ingredient() { IngredientId = 11, IngredientName = "Dark Brown Sugar", IngredientType = "Sweets" },
                new Ingredient() { IngredientId = 12, IngredientName = "Light Brown Sugar", IngredientType = "Sweets" },
                new Ingredient() { IngredientId = 13, IngredientName = "Blueberries", IngredientType = "Fruits" },
                new Ingredient() { IngredientId = 14, IngredientName = "Strawberries", IngredientType = "Fruits" },
                new Ingredient() { IngredientId = 15, IngredientName = "Mangoes", IngredientType = "Fruit" },
                new Ingredient() { IngredientId = 16, IngredientName = "Almonds", IngredientType = "Nuts" },
                new Ingredient() { IngredientId = 17, IngredientName = "Yogurt", IngredientType = "Dairy" },
                new Ingredient() { IngredientId = 18, IngredientName = "Sour Cream", IngredientType = "Dairy" },
                new Ingredient() { IngredientId = 19, IngredientName = "Cardamon", IngredientType = "Spices/Herbs/Seasonings" },
                new Ingredient() { IngredientId = 20, IngredientName = "Saffron", IngredientType = "Spices/Herbs/Seasonings" },
                new Ingredient() { IngredientId = 21, IngredientName = "Pistashios", IngredientType = "Nuts" },
                new Ingredient() { IngredientId = 22, IngredientName = "Strawberry Jam", IngredientType = "Jams/Jellies/Preserves" },
                new Ingredient() { IngredientId = 23, IngredientName = "Whole Wheat Flour", IngredientType = "Gluten" },
                new Ingredient() { IngredientId = 24, IngredientName = "Self-Rising Flour", IngredientType = "Gluten" },
                new Ingredient() { IngredientId = 25, IngredientName = "Butter", IngredientType = "Dairy" },
                new Ingredient() { IngredientId = 26, IngredientName = "Almond Extract", IngredientType = "Extracts" },
                new Ingredient() { IngredientId = 27, IngredientName = "Vanilla Extract", IngredientType = "Extracts" },
                new Ingredient() { IngredientId = 28, IngredientName = "Vanilla Bean Paste", IngredientType = "Other" },
                new Ingredient() { IngredientId = 29, IngredientName = "Egg Whites", IngredientType = "Dairy" },
                new Ingredient() { IngredientId = 30, IngredientName = "Egg Yolks", IngredientType = "Dairy" },
                new Ingredient() { IngredientId = 31, IngredientName = "Cream of Tartar", IngredientType = "Spices/Herbs/Seasonings" },
                new Ingredient() { IngredientId = 32, IngredientName = "Bread Flour", IngredientType = "Gluten" },
                new Ingredient() { IngredientId = 33, IngredientName = "Active Dry Yeast", IngredientType = "Other" },
                new Ingredient() { IngredientId = 34, IngredientName = "Lemon Juice", IngredientType = "Fruit" },
                new Ingredient() { IngredientId = 35, IngredientName = "Lemon Zest", IngredientType = "Other" },
                new Ingredient() { IngredientId = 36, IngredientName = "Shrimp", IngredientType = "Fish" },
                new Ingredient() { IngredientId = 37, IngredientName = "Pork", IngredientType = "Meat" },
                new Ingredient() { IngredientId = 38, IngredientName = "Potato", IngredientType = "Vegetable" },
                new Ingredient() { IngredientId = 39, IngredientName = "Green Beans", IngredientType = "Vegetable" },
                new Ingredient() { IngredientId = 40, IngredientName = "Eggplant", IngredientType = "Vegetable" },
                new Ingredient() { IngredientId = 41, IngredientName = "Mustard", IngredientType = "Other" },
                new Ingredient() { IngredientId = 42, IngredientName = "Soy Sauce", IngredientType = "Other" },
                new Ingredient() { IngredientId = 43, IngredientName = "White Rice", IngredientType = "Gluten" },
                new Ingredient() { IngredientId = 44, IngredientName = "Carrots", IngredientType = "Vegetable" },
                new Ingredient() { IngredientId = 45, IngredientName = "Kale", IngredientType = "Vegetable" },
                new Ingredient() { IngredientId = 46, IngredientName = "Cinnamon", IngredientType = "Spices/Herbs/Seasonings" },
                new Ingredient() { IngredientId = 47, IngredientName = "Peaches", IngredientType = "Fruit" },
                new Ingredient() { IngredientId = 48, IngredientName = "Oranges", IngredientType = "Fruit" },
                new Ingredient() { IngredientId = 49, IngredientName = "Salmon", IngredientType = "Fish" },
                new Ingredient() { IngredientId = 50, IngredientName = "Cauliflower", IngredientType = "Vegetable" },
                new Ingredient() { IngredientId = 51, IngredientName = "Cucumbers", IngredientType = "Vegetable" },
                new Ingredient() { IngredientId = 52, IngredientName = "Ribs", IngredientType = "Meat" },
                new Ingredient() { IngredientId = 53, IngredientName = "BBQ Sauce", IngredientType = "Other" },
                new Ingredient() { IngredientId = 54, IngredientName = "Tilapia", IngredientType = "Fish" },
                new Ingredient() { IngredientId = 55, IngredientName = "Pork Chops", IngredientType = "Meat" },
                new Ingredient() { IngredientId = 56, IngredientName = "Bacon", IngredientType = "Meat" },
                new Ingredient() { IngredientId = 57, IngredientName = "Raspberries", IngredientType = "Fruit" },
                new Ingredient() { IngredientId = 58, IngredientName = "Olive Oil", IngredientType = "Other" },
                new Ingredient() { IngredientId = 59, IngredientName = "Artichokes", IngredientType = "Vegetable" },
                new Ingredient() { IngredientId = 60, IngredientName = "Lettuce", IngredientType = "Vegetable" },
                new Ingredient() { IngredientId = 61, IngredientName = "Tomatoes", IngredientType = "Vegetable" },
                new Ingredient() { IngredientId = 62, IngredientName = "Chicken Broth", IngredientType = "Other" },
                new Ingredient() { IngredientId = 63, IngredientName = "Beef Broth", IngredientType = "Other" },
                new Ingredient() { IngredientId = 64, IngredientName = "Heavy Cream", IngredientType = "Dairy" },
                new Ingredient() { IngredientId = 65, IngredientName = "Cornstarch", IngredientType = "Other" },
                new Ingredient() { IngredientId = 66, IngredientName = "Blackberries", IngredientType = "Dairy" }

                );
            }
        }
    }

