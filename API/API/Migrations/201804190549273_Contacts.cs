namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        EntryID = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        AccountNumber = c.String(),
                        DeviceID = c.String(),
                    })
                .PrimaryKey(t => t.EntryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
