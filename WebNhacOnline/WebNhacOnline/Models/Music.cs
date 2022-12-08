using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebNhacOnline.Models
{
    [Bind(Exclude = "MusicId")]
    public class Music
    {
        [ScaffoldColumn(false)]   // ẩn hoặc hiển thị trường lên form //false: ẩn, true: hiển thị
        public int MusicId { get; set; }
        [DisplayName("Chọn album cho bài nhạc")]
        public int AlbumId { get; set; }   // Album ex: nhạc vàng, nhạc trữ tình, rock
        [DisplayName("Chọn nghệ sĩ cho bài nhạc")]
        public int ArtistId { get; set; } //nghệ sĩ nhạc
        [DisplayName("Tên bài nhạc")]
        [Required(ErrorMessage = "Tên bài nhạc là trường bắt buộc giới hạn 50 ký tự")]
        [StringLength(50)]
        public string Title { get; set; }
        [DisplayName("Lời bài nhạc")]
        public string Lyric { get; set; } // lời bài nhạc
        [DisplayName("Ca sĩ trình bài")]
        public string Singer { get; set; } // ca sĩ trình bài
        public Artist Artist { get; set; }
        public string ErrorMessage { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadUserFile { get; set; }
    }
}