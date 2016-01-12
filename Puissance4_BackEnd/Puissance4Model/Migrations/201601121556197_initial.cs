namespace Puissance4Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Board",
                c => new
                    {
                        Game_ID = c.Int(nullable: false),
                        Content = c.String(),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Game_ID)
                .ForeignKey("dbo.Game", t => t.Game_ID)
                .Index(t => t.Game_ID);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DStart = c.DateTimeOffset(nullable: false, precision: 7),
                        DEnd = c.DateTimeOffset(nullable: false, precision: 7),
                        P1_Id = c.String(maxLength: 128),
                        P2_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stat",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Turn = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        BNull = c.Boolean(nullable: false),
                        Plose_Id = c.String(maxLength: 128),
                        Pwin_Id = c.String(maxLength: 128),
                        User1_ID = c.Int(),
                        Users2_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.User1_ID)
                .ForeignKey("dbo.User", t => t.Users2_ID)
                .Index(t => t.User1_ID)
                .Index(t => t.Users2_ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stat", "Users2_ID", "dbo.User");
            DropForeignKey("dbo.Stat", "User1_ID", "dbo.User");
            DropForeignKey("dbo.Board", "Game_ID", "dbo.Game");
            DropIndex("dbo.Stat", new[] { "Users2_ID" });
            DropIndex("dbo.Stat", new[] { "User1_ID" });
            DropIndex("dbo.Board", new[] { "Game_ID" });
            DropTable("dbo.User");
            DropTable("dbo.Stat");
            DropTable("dbo.Game");
            DropTable("dbo.Board");
        }
    }
}
