namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PublicationDate = c.DateTime(nullable: false),
                        Duration = c.Double(nullable: false),
                        Link = c.String(),
                        CountryId = c.Int(nullable: false),
                        JanreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Janres", t => t.JanreId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.JanreId);
            
            CreateTable(
                "dbo.Janres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "JanreId", "dbo.Janres");
            DropForeignKey("dbo.Films", "CountryId", "dbo.Countries");
            DropIndex("dbo.Films", new[] { "JanreId" });
            DropIndex("dbo.Films", new[] { "CountryId" });
            DropTable("dbo.Janres");
            DropTable("dbo.Films");
            DropTable("dbo.Countries");
        }
    }
}
