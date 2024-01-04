using System.ComponentModel.DataAnnotations;

namespace E_State.UI.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Boş geçilemez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Boş geçilemez")]
        [DataType(DataType.Password, ErrorMessage = "Şifre tipinde değil")]
        public string Password { get; set; }
    }
}
