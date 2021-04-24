namespace RecipeKeeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheMillionth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipe", "AuthorName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipe", "AuthorName", c => c.String(nullable: false));
        }
    }
}
