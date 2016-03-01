namespace LastBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mothe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyModels", "maxMoney", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyModels", "presentable", c => c.Boolean(nullable: false));
            AlterColumn("dbo.SurveyModels", "appearance", c => c.Int(nullable: false));
            DropColumn("dbo.SurveyModels", "Money");
            DropColumn("dbo.SurveyModels", "Looks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurveyModels", "Looks", c => c.Int(nullable: false));
            AddColumn("dbo.SurveyModels", "Money", c => c.Int(nullable: false));
            AlterColumn("dbo.SurveyModels", "appearance", c => c.Boolean(nullable: false));
            DropColumn("dbo.SurveyModels", "presentable");
            DropColumn("dbo.SurveyModels", "maxMoney");
        }
    }
}
