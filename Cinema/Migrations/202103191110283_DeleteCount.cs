namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Seats", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "Count", c => c.Int(nullable: false));
        }
    }
}
