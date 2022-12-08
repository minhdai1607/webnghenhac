using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace WebNhacOnline.Models
{
    public class MusicStoreEntities : DbContext
    {
        public DbSet<Album> Albums { get; set; }  // nhạc
        public DbSet<Genre> Genres { get; set; }  // thể loại nhạc rock, cổ điển
        public DbSet<User> Users { get; set; }   // người up
        public DbSet<Artist> Artists { get; set; }    // Tác giả hoặc nghệ sĩ trình bài
        public DbSet<Music> Musics { get; set; }
    }

}