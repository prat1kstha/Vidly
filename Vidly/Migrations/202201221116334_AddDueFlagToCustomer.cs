namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDueFlagToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsDue", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsDue");
        }
    }
}
