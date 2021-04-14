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
            ContextKey = "RecipeKeeper.Data.ApplicationDbContext";
        }

        protected override void Seed(RecipeKeeper.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
       //     context.Authors.AddOrUpdate(x => x.Id,
       //new Author() { Id = 1, Name = "Jane Austen" },
       //new Author() { Id = 2, Name = "Charles Dickens" },
       //new Author() { Id = 3, Name = "Miguel de Cervantes" }
       //);
       //     context.Ingredients.
       //     new Ingredient { Ingredient }

        }
    }
}
