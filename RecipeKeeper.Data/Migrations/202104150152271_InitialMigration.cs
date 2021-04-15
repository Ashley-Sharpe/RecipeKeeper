namespace RecipeKeeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                {
                    BookId = c.Int(nullable: false, identity: true),
                    BookName = c.String(),
                    Author = c.String(),
                })
                .PrimaryKey(t => t.BookId);

            CreateTable(
                "dbo.Ingredients",
                c => new
                {
                    IngredientId = c.Int(nullable: false, identity: true),
                    IngredientName = c.String(nullable: false),
                    IngredientType = c.String(),
                    Recipe_RecipeId = c.Int(),
                    Recipe_RecipeId1 = c.Int(),
                })
                .PrimaryKey(t => t.IngredientId)
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeId)
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeId1)
                .Index(t => t.Recipe_RecipeId)
                .Index(t => t.Recipe_RecipeId1);

            CreateTable(
                "dbo.Recipes",
                c => new
                {
                    RecipeId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    RecipeName = c.String(),
                    BookName = c.String(),
                    PageNumber = c.Int(),
                    RecipeType = c.String(nullable: false),
                    CuisineType = c.String(nullable: false),
                    AuthorName = c.String(nullable: false),
                    BookId = c.Int(nullable: false),
                    Ingredient_IngredientId = c.Int(),
                    Ingredient_IngredientId1 = c.Int(),
                })
                .PrimaryKey(t => t.RecipeId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_IngredientId)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_IngredientId1)
                .Index(t => t.BookId)
                .Index(t => t.Ingredient_IngredientId)
                .Index(t => t.Ingredient_IngredientId1);

            CreateTable(
                "dbo.Pantrys",
                c => new
                {
                    PantryId = c.Int(nullable: false, identity: true),
                    IngredientName = c.String(),
                    InStock = c.Boolean(nullable: false),
                    Location = c.String(nullable: false),
                    Quantity = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.PantryId);
        }
            

        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Recipe", "Ingredient_IngredientId1", "dbo.Ingredient");
            DropForeignKey("dbo.Recipe", "Ingredient_IngredientId", "dbo.Ingredient");
            DropForeignKey("dbo.Ingredient", "Recipe_RecipeId1", "dbo.Recipe");
            DropForeignKey("dbo.Ingredient", "Recipe_RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Recipe", "BookId", "dbo.Book");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Recipe", new[] { "Ingredient_IngredientId1" });
            DropIndex("dbo.Recipe", new[] { "Ingredient_IngredientId" });
            DropIndex("dbo.Recipe", new[] { "BookId" });
            DropIndex("dbo.Ingredient", new[] { "Recipe_RecipeId1" });
            DropIndex("dbo.Ingredient", new[] { "Recipe_RecipeId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Pantry");
            DropTable("dbo.Recipe");
            DropTable("dbo.Ingredient");
            DropTable("dbo.Book");
        }
    }
}
