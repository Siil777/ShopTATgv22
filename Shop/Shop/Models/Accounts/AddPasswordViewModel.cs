using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Accounts
{
    public class AddPasswordViewModel
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]

        public string NewPassword { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not may match")]
        public string ConfirmPassword { get; set; }
    }
}
