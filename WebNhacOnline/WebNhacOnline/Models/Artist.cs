using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace WebNhacOnline.Models
{
    [Bind(Exclude = "ArtistId")]
    public class Artist
    {
        [ScaffoldColumn(false)]   // ẩn hoặc hiển thị trường lên form //false: ẩn, true: hiển thị
        public int ArtistId { get; set; }
        [DisplayName("Tên nghệ sĩ")]
        [Required(ErrorMessage = "Tên nghệ sĩ không được để trống, giới hạn 50 ký tự")]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Mô tả về nghệ sĩ")]
        [MaxLength(300)]
        public string Decscription { get; set; }

    }
}