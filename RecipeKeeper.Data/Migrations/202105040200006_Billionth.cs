namespace RecipeKeeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Billionth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ingredient", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredient", "Quantity", c => c.Int(nullable: false));
        }
    }
}
