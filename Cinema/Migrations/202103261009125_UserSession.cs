namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSession : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Films", "UserId");
            AddForeignKey("dbo.Films", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "UserId", "dbo.Users");
            DropIndex("dbo.Films", new[] { "UserId" });
            DropColumn("dbo.Films", "UserId");
        }
    }
}
