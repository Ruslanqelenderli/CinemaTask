namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManyToManyAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Films", "JanreId", "dbo.Janres");
            DropForeignKey("dbo.ManyToManies", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.ManyToManies", "JanreId", "dbo.Janres");
            DropIndex("dbo.Films", new[] { "CountryId" });
            DropIndex("dbo.Films", new[] { "JanreId" });
            DropIndex("dbo.ManyToManies", new[] { "CountryId" });
            DropIndex("dbo.ManyToManies", new[] { "JanreId" });
            CreateTable(
                "dbo.FilmCountries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.FilmJanres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        JanreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .ForeignKey("dbo.Janres", t => t.JanreId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.JanreId);
            
            DropColumn("dbo.Films", "CountryId");
            DropColumn("dbo.Films", "JanreId");
            DropTable("dbo.ManyToManies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ManyToManies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        JanreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Films", "JanreId", c => c.Int(nullable: false));
            AddColumn("dbo.Films", "CountryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.FilmJanres", "JanreId", "dbo.Janres");
            DropForeignKey("dbo.FilmJanres", "FilmId", "dbo.Films");
            DropForeignKey("dbo.FilmCountries", "FilmId", "dbo.Films");
            DropForeignKey("dbo.FilmCountries", "CountryId", "dbo.Countries");
            DropIndex("dbo.FilmJanres", new[] { "JanreId" });
            DropIndex("dbo.FilmJanres", new[] { "FilmId" });
            DropIndex("dbo.FilmCountries", new[] { "CountryId" });
            DropIndex("dbo.FilmCountries", new[] { "FilmId" });
            DropTable("dbo.FilmJanres");
            DropTable("dbo.FilmCountries");
            CreateIndex("dbo.ManyToManies", "JanreId");
            CreateIndex("dbo.ManyToManies", "CountryId");
            CreateIndex("dbo.Films", "JanreId");
            CreateIndex("dbo.Films", "CountryId");
            AddForeignKey("dbo.ManyToManies", "JanreId", "dbo.Janres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ManyToManies", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Films", "JanreId", "dbo.Janres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Films", "CountryId", "dbo.Countries", "Id", cascadeDelete: true);
        }
    }
}
