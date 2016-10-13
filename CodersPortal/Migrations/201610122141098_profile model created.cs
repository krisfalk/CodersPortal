namespace CodersPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profilemodelcreated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "userHTML");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "userHTML", c => c.String());
        }
    }
}
