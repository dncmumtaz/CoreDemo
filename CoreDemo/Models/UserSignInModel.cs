using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignInModel
    {
        [Display(Name = "Name Surname")]
        [Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }
    }
}
