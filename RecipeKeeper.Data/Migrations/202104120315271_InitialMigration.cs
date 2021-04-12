namespace RecipeKeeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "RecipeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipe", "RecipeName");
        }
    }
}
