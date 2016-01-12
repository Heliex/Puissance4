namespace Puissance4Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        P1_Id = c.String(maxLength: 128),
                        P2_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.P1_Id)
                .ForeignKey("dbo.IdentityUsers", t => t.P2_Id)
                .Index(t => t.P1_Id)
                .Index(t => t.P2_Id);
            
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        IdGame_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.IdGame_Id)
                .Index(t => t.IdGame_Id);
            
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Turn = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        BNull = c.Boolean(nullable: false),
                        Plose_Id = c.String(maxLength: 128),
                        Pwin_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.Plose_Id)
                .ForeignKey("dbo.IdentityUsers", t => t.Pwin_Id)
                .Index(t => t.Plose_Id)
                .Index(t => t.Pwin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stats", "Pwin_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Stats", "Plose_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Games", "P2_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Games", "P1_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Boards", "IdGame_Id", "dbo.Games");
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.IdentityUsers");
            DropIndex("dbo.Stats", new[] { "Pwin_Id" });
            DropIndex("dbo.Stats", new[] { "Plose_Id" });
            DropIndex("dbo.Boards", new[] { "IdGame_Id" });
            DropIndex("dbo.Games", new[] { "P2_Id" });
            DropIndex("dbo.Games", new[] { "P1_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropTable("dbo.Stats");
            DropTable("dbo.Boards");
            DropTable("dbo.Games");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.AspNetUsers");
        }
    }
}
