using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace WebNhacOnline.Models
{
    [Bind(Exclude = "GenreId")]
    public class Genre
    {
        [ScaffoldColumn(false)]   // ẩn hoặc hiển thị trường lên form //false: ẩn, true: hiển thị
        public int GenreId { get; set; }
        [DisplayName("Tên thể loại nhạc")]
        [Required(ErrorMessage = "Tên thể loại nhạc không được để trống, giới hạn 50 ký tự")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Mô tả thể loại")]
        [MaxLength(300)]
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}