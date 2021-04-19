namespace RecipeKeeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        Author = c.String(),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(nullable: false),
                        IngredientType = c.String(),
                        Recipe_RecipeId = c.Int(),
                        Recipe_RecipeId1 = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientId)
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeId)
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeId1)
                .Index(t => t.Recipe_RecipeId)
                .Index(t => t.Recipe_RecipeId1);
            
            CreateTable(
                "dbo.Recipe",
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
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_IngredientId)
                .ForeignKey("dbo.Ingredient", t => t.Ingredient_IngredientId1)
                .Index(t => t.BookId)
                .Index(t => t.Ingredient_IngredientId)
                .Index(t => t.Ingredient_IngredientId1);
            
            CreateTable(
                "dbo.Pantry",
                c => new
                    {
                        PantryId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                        InStock = c.Boolean(nullable: false),
                        Location = c.String(nullable: false),
                        Quantity = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PantryId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
