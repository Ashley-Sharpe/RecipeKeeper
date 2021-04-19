namespace RecipeKeeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPantry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pantry", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pantry", "OwnerId");
        }
    }
}
