
using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Name Surname")]
        [Required(ErrorMessage = "Enter Name Surname")]
        public string NameSurname { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage =  "Password does not match")]
        [Required(ErrorMessage = "Enter Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Enter Mail")]
        public string Mail { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Enter UserName")]
        public string UserName { get; set; }
    }
}
