namespace PropertyManager.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpellCheck : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tenants", "Telephone", c => c.String());
            AddColumn("dbo.Tenants", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tenants", "EmailAddress");
            DropColumn("dbo.Tenants", "Telephone");
        }
    }
}
