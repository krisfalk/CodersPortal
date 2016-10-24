namespace CodersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcommentdbset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        NewsArticleId = c.Int(nullable: false),
                        Name = c.String(),
                        UserComment = c.String(),
                        postDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.NewsArticles", t => t.NewsArticleId, cascadeDelete: true)
                .Index(t => t.NewsArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "NewsArticleId", "dbo.NewsArticles");
            DropIndex("dbo.Comments", new[] { "NewsArticleId" });
            DropTable("dbo.Comments");
        }
    }
}
