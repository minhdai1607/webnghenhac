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
    [Bind(Exclude = "UserId")]  // dùng để trói buộc, bắt hệ thống phải check các data require.
    // được giải thích như sau: Trường hợp mình ko show ID ra form thì người dùng sẽ ko nhập dc nhưng đây lại là trường bắt buộc vì vậy bind
    // tại sao không show ra form vì yêu cầu trong user story không đề cập và đánh giá nó ko cần thiết hiển thị.
    // Nếu như làm mã nhân viên hoặc người dùng muốn tự nhập vào mã ví dụ mã nhân viên, mã sản phẩm thì sẽ yêu cầu hiện cho nhập
    // Quan trong tránh conflic data thì ẩn cho bền
    public class User
    {
        [ScaffoldColumn(false)]   // ẩn hoặc hiển thị trường lên form //false: ẩn, true: hiển thị
        public int UserId { get; set; }
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string UserName { get; set; }

        public int? Role { get; set; }
        [DisplayName("Tên người dùng")]
        [Required(ErrorMessage = "Tên người dùng không được để trống")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nhập vào địa chỉ email của bạn")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Vui lòng nhập đúng định dạng email")]
        public string Gmail { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        //[Range(8, 16, ErrorMessage = "Mật khẩu phải từ 8 đến 16 ký tự")]
        public string Password { get; set; }
        public string Userimage { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadUserFile { get; set; }

    }
    
}