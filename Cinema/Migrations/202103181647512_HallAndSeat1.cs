namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HallAndSeat1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Seats", "HallId");
            AddForeignKey("dbo.Seats", "HallId", "dbo.Halls", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seats", "HallId", "dbo.Halls");
            DropIndex("dbo.Seats", new[] { "HallId" });
        }
    }
}
