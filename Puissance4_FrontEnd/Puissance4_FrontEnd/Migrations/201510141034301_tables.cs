namespace Puissance4_FrontEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
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
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
            
            AddColumn("dbo.AspNetUserRoles", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "IdentityUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String());
            CreateIndex("dbo.AspNetUserClaims", "IdentityUser_Id");
            CreateIndex("dbo.AspNetUserLogins", "IdentityUser_Id");
            CreateIndex("dbo.AspNetUserRoles", "IdentityUser_Id");
            CreateIndex("dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Id", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.IdentityUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Email");
            DropColumn("dbo.AspNetUsers", "EmailConfirmed");
            DropColumn("dbo.AspNetUsers", "PasswordHash");
            DropColumn("dbo.AspNetUsers", "SecurityStamp");
            DropColumn("dbo.AspNetUsers", "PhoneNumber");
            DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed");
            DropColumn("dbo.AspNetUsers", "TwoFactorEnabled");
            DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
            DropColumn("dbo.AspNetUsers", "LockoutEnabled");
            DropColumn("dbo.AspNetUsers", "AccessFailedCount");
            DropColumn("dbo.AspNetUsers", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String());
            AddColumn("dbo.AspNetUsers", "PasswordHash", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Stats", "Pwin_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Stats", "Plose_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Boards", "IdGame_Id", "dbo.Games");
            DropForeignKey("dbo.Games", "P2_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.Games", "P1_Id", "dbo.IdentityUsers");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.Stats", new[] { "Pwin_Id" });
            DropIndex("dbo.Stats", new[] { "Plose_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.IdentityUsers", "UserNameIndex");
            DropIndex("dbo.Games", new[] { "P2_Id" });
            DropIndex("dbo.Games", new[] { "P1_Id" });
            DropIndex("dbo.Boards", new[] { "IdGame_Id" });
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.AspNetUserLogins", "IdentityUser_Id");
            DropColumn("dbo.AspNetUserClaims", "IdentityUser_Id");
            DropColumn("dbo.AspNetUserRoles", "IdentityUser_Id");
            DropTable("dbo.Stats");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.Games");
            DropTable("dbo.Boards");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
