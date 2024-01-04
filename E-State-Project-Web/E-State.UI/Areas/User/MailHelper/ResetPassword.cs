using System.Net.Mail;

namespace E_State.UI.Areas.User.MailHelper
{
    public class ResetPassword
    {
        public static void PasswordSendMail(string link)
        {
            MailMessage mail = new MailMessage();

            SmtpClient smtp = new SmtpClient();

            mail.From = new MailAddress("sytem@mail.com");

            mail.To.Add("f211229018@ktun.edu.tr");

            mail.Subject = "Şifre güncelleme talebi";

            mail.Body = "<h2>Şifrenizi yenilemek için linke tıklayınız </h2> <hr>";
            mail.Body += $"<a href='{link}'> Şifre yenileme bağlantısı";

            mail.IsBodyHtml = true;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("f211229018@ktun.edu.tr", "Msy1306software");
            smtp.Send(mail);

        }
    }
}
