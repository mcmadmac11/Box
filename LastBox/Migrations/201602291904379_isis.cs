namespace LastBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisteredUsers", "BoxName", c => c.String());
            AddColumn("dbo.RegisteredUsers", "BoxPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RegisteredUsers", "BoxPrice");
            DropColumn("dbo.RegisteredUsers", "BoxName");
        }
    }
}
