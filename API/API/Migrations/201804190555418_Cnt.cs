namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cnt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsVarified", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "IsVarified");
        }
    }
}
