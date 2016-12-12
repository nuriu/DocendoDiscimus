namespace servis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        Kimlik = c.Int(nullable: false, identity: true),
                        Eposta = c.String(nullable: false, maxLength: 50),
                        KullaniciAdi = c.String(nullable: false, maxLength: 50),
                        Isim = c.String(maxLength: 50),
                        Soyisim = c.String(maxLength: 50),
                        Parola = c.String(nullable: false, maxLength: 64),
                        KullaniciTuru = c.Boolean(nullable: false),
                        AvatarLink = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Kimlik);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kullanici");
        }
    }
}
