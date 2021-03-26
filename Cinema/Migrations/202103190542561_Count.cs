namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Count : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Seats", "Count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Seats", "Count");
        }
    }
}
