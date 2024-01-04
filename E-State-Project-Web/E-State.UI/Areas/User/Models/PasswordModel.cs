using System.ComponentModel.DataAnnotations;

namespace E_State.UI.Areas.User.Models
{
    public class PasswordModel
    {
        [Required(ErrorMessage = "Boş geçilemez")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil")]
        public string ConfirmedPassword { get; set; }
    }
}
