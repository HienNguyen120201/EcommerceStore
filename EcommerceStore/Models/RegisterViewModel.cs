using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Vui lòng điền tên đăng nhập")]
        [StringLength(16,MinimumLength = 8,ErrorMessage = "Tên đăng nhập phải từ 8-16 kí tự")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Vui lòng điền tên mật khẩu")]
        [StringLength(16,MinimumLength = 8,ErrorMessage = "Mật khẩu phải từ 8-16 kí tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@~%&]).{8,}$",ErrorMessage ="Mật khẩu phải có ít nhất một ký tự in hoa, số và ký tự đặc biệt")]
        public string Password { get; set; }
        [Required()]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "Vui lòng điền tên")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng điền số điện thoại")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng điền email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng điền giới tính")]
        public bool Gender { get; set; }
        [Required(ErrorMessage = "Vui lòng điền ngày sinh")]
        public DateTime Birthday { get; set; }
        public string ErrorMessage { get; set; }
    }
}
