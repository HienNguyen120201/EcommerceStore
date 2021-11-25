using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceStore.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [StringLength(16,MinimumLength = 8,ErrorMessage = "Mật khẩu phải từ 8-16 kí tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@~%&]).{8,}$",ErrorMessage ="Mật khẩu phải có ít nhất một ký tự in hoa, số và ký tự đặc biệt")]
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string ErrorMessage { get; set; }
    }
}
