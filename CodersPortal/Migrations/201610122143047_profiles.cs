namespace CodersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        profileId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        userHTML = c.String(),
                    })
                .PrimaryKey(t => t.profileId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "UserId" });
            DropTable("dbo.Profiles");
        }
    }
}
