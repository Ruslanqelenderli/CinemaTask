namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyAdded3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.FilmCountries", "FilmId");
            AddForeignKey("dbo.FilmCountries", "FilmId", "dbo.Films", "Id", cascadeDelete: true);
            DropColumn("dbo.FilmCountries", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FilmCountries", "MyProperty", c => c.Int(nullable: false));
            DropForeignKey("dbo.FilmCountries", "FilmId", "dbo.Films");
            DropIndex("dbo.FilmCountries", new[] { "FilmId" });
        }
    }
}
