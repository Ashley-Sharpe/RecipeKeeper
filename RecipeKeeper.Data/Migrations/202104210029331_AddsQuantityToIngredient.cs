namespace RecipeKeeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsQuantityToIngredient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredient", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingredient", "Quantity");
        }
    }
}
