namespace WebNhacOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class music : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        GenreId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Decscription = c.String(maxLength: 300),
                        Artist_ArtistId = c.Int(),
                    })
                .PrimaryKey(t => t.AlbumId)
                .ForeignKey("dbo.Artists", t => t.Artist_ArtistId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.Artist_ArtistId);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Decscription = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Musics",
                c => new
                    {
                        MusicId = c.Int(nullable: false, identity: true),
                        AlbumId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Lyric = c.String(),
                        Singer = c.String(),
                        ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.MusicId)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Role = c.Int(),
                        Name = c.String(nullable: false, maxLength: 50),
                        Gmail = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Userimage = c.String(),
                        Status = c.Int(nullable: false),
                        ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musics", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.Albums", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Albums", "Artist_ArtistId", "dbo.Artists");
            DropIndex("dbo.Musics", new[] { "ArtistId" });
            DropIndex("dbo.Albums", new[] { "Artist_ArtistId" });
            DropIndex("dbo.Albums", new[] { "GenreId" });
            DropTable("dbo.Users");
            DropTable("dbo.Musics");
            DropTable("dbo.Genres");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
