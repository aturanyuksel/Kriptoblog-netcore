namespace Haber.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class turanhaber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Etiket",
                c => new
                    {
                        EtiketID = c.Int(nullable: false, identity: true),
                        EtiketAdi = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.EtiketID);
            
            CreateTable(
                "dbo.Haber",
                c => new
                    {
                        HaberID = c.Int(nullable: false, identity: true),
                        HaberBaslik = c.String(nullable: false),
                        HaberIcerik = c.String(nullable: false),
                        HaberGirisTarihi = c.DateTime(nullable: false),
                        HaberDurumu = c.Boolean(nullable: false),
                        HaberOkunmaSayisi = c.Int(nullable: false),
                        HaberKategori_KategoriID = c.Int(),
                        HaberYazari_YazarID = c.Int(),
                    })
                .PrimaryKey(t => t.HaberID)
                .ForeignKey("dbo.Kategori", t => t.HaberKategori_KategoriID)
                .ForeignKey("dbo.Yazar", t => t.HaberYazari_YazarID)
                .Index(t => t.HaberKategori_KategoriID)
                .Index(t => t.HaberYazari_YazarID);
            
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        KategoriID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false),
                        KategoriAciklama = c.String(),
                    })
                .PrimaryKey(t => t.KategoriID);
            
            CreateTable(
                "dbo.Resim",
                c => new
                    {
                        ResimID = c.Int(nullable: false, identity: true),
                        ResimAdi = c.String(nullable: false),
                        ResimHaber_HaberID = c.Int(),
                    })
                .PrimaryKey(t => t.ResimID)
                .ForeignKey("dbo.Haber", t => t.ResimHaber_HaberID)
                .Index(t => t.ResimHaber_HaberID);
            
            CreateTable(
                "dbo.Yazar",
                c => new
                    {
                        YazarID = c.Int(nullable: false, identity: true),
                        YazarAdSoyad = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.YazarID);
            
            CreateTable(
                "dbo.Yorum",
                c => new
                    {
                        YorumID = c.Int(nullable: false, identity: true),
                        YorumYazari = c.String(nullable: false),
                        YorumIcerik = c.String(nullable: false),
                        YorumYazmaTarihi = c.DateTime(nullable: false),
                        YorumDurumu = c.Boolean(nullable: false),
                        YorumHaberi_HaberID = c.Int(),
                    })
                .PrimaryKey(t => t.YorumID)
                .ForeignKey("dbo.Haber", t => t.YorumHaberi_HaberID)
                .Index(t => t.YorumHaberi_HaberID);
            
            CreateTable(
                "dbo.Hakkimizda",
                c => new
                    {
                        HakID = c.Int(nullable: false, identity: true),
                        HakBaslik = c.String(nullable: false),
                        HakIcerik = c.String(nullable: false),
                        HakEklenmeTarihi = c.DateTime(nullable: false),
                        HakAktiflik = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HakID);
            
            CreateTable(
                "dbo.Iletisim",
                c => new
                    {
                        IletisimID = c.Int(nullable: false, identity: true),
                        IltAdSoyad = c.String(nullable: false),
                        email = c.String(nullable: false),
                        IltKonu = c.String(nullable: false),
                        IltIcerik = c.String(nullable: false),
                        IltGondermeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IletisimID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        SurName = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.HaberClEtiket",
                c => new
                    {
                        HaberCl_HaberID = c.Int(nullable: false),
                        Etiket_EtiketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HaberCl_HaberID, t.Etiket_EtiketID })
                .ForeignKey("dbo.Haber", t => t.HaberCl_HaberID, cascadeDelete: true)
                .ForeignKey("dbo.Etiket", t => t.Etiket_EtiketID, cascadeDelete: true)
                .Index(t => t.HaberCl_HaberID)
                .Index(t => t.Etiket_EtiketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Yorum", "YorumHaberi_HaberID", "dbo.Haber");
            DropForeignKey("dbo.Haber", "HaberYazari_YazarID", "dbo.Yazar");
            DropForeignKey("dbo.Resim", "ResimHaber_HaberID", "dbo.Haber");
            DropForeignKey("dbo.Haber", "HaberKategori_KategoriID", "dbo.Kategori");
            DropForeignKey("dbo.HaberClEtiket", "Etiket_EtiketID", "dbo.Etiket");
            DropForeignKey("dbo.HaberClEtiket", "HaberCl_HaberID", "dbo.Haber");
            DropIndex("dbo.HaberClEtiket", new[] { "Etiket_EtiketID" });
            DropIndex("dbo.HaberClEtiket", new[] { "HaberCl_HaberID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Yorum", new[] { "YorumHaberi_HaberID" });
            DropIndex("dbo.Resim", new[] { "ResimHaber_HaberID" });
            DropIndex("dbo.Haber", new[] { "HaberYazari_YazarID" });
            DropIndex("dbo.Haber", new[] { "HaberKategori_KategoriID" });
            DropTable("dbo.HaberClEtiket");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Iletisim");
            DropTable("dbo.Hakkimizda");
            DropTable("dbo.Yorum");
            DropTable("dbo.Yazar");
            DropTable("dbo.Resim");
            DropTable("dbo.Kategori");
            DropTable("dbo.Haber");
            DropTable("dbo.Etiket");
        }
    }
}
