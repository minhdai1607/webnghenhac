using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace WebNhacOnline.Models
{
    [Bind(Exclude = "AlbumId")]
    public class Album
    {
        [ScaffoldColumn(false)]   // ẩn hoặc hiển thị trường lên form //false: ẩn, true: hiển thị
        public int AlbumId { get; set; }

        [DisplayName("Thể loại nhạc")]
        [Required(ErrorMessage = "Vui lòng chọn thể loại nhạc")]
        public int GenreId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Tên Album là trường bắt buộc giới hạn 50 ký tự")]
        [StringLength(50)]
        [DisplayName("Tên Album")]
        public string Title { get; set; }
        [DisplayName("Mô tả Album")]
        [StringLength(300)]
        public string Decscription { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

    }
}