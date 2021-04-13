namespace RecipeKeeper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
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
                    })
                .PrimaryKey(t => t.BookId);
            
            AddColumn("dbo.Recipe", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipe", "BookId");
            AddForeignKey("dbo.Recipe", "BookId", "dbo.Book", "BookId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipe", "BookId", "dbo.Book");
            DropIndex("dbo.Recipe", new[] { "BookId" });
            DropColumn("dbo.Recipe", "BookId");
            DropTable("dbo.Book");
        }
    }
}
