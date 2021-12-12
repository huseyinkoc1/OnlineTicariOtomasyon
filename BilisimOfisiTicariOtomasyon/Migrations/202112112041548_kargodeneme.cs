namespace BilisimOfisiTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargodeneme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        kargoId = c.Int(nullable: false, identity: true),
                        kargoAciklama = c.String(maxLength: 100, unicode: false),
                        kargoTakipKodu = c.String(maxLength: 10, unicode: false),
                        kargoPersonel = c.String(maxLength: 50, unicode: false),
                        kargoMusteri = c.String(maxLength: 50, unicode: false),
                        kargoTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.kargoId);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        kargoTakipId = c.Int(nullable: false, identity: true),
                        kargoTakipKodu = c.String(maxLength: 10, unicode: false),
                        kargoTakipAciklama = c.String(maxLength: 100, unicode: false),
                        kargoTakipTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.kargoTakipId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}
