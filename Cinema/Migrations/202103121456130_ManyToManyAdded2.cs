namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyAdded2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilmCountries", "FilmId", "dbo.Films");
            DropIndex("dbo.FilmCountries", new[] { "FilmId" });
            AddColumn("dbo.FilmCountries", "MyProperty", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FilmCountries", "MyProperty");
            CreateIndex("dbo.FilmCountries", "FilmId");
            AddForeignKey("dbo.FilmCountries", "FilmId", "dbo.Films", "Id", cascadeDelete: true);
        }
    }
}
