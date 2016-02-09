namespace PropertyManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpellCheck1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkOrders", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkOrders", "Priority");
        }
    }
}
