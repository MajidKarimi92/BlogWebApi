using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Data.Dto.Account
{
    public class SignUpInputDto
    {
        [Required(ErrorMessage = "ایمیل خالی می‌باشد")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "رمز عبور خالی می‌باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "تایید رمز عبور خالی می‌باشد")]
        [Compare("Password", ErrorMessage = "رمز عبور و تایید آن مطابقت ندارند")]
        public string ConfirmPassword { get; set; }
        public string UserRole { get; set; }
    }
}
