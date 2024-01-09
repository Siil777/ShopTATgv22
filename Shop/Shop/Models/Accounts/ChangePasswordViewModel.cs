using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Accounts
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]

        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]

        public string NewPassword { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("New Password", ErrorMessage = "The new password and confirmation password do not may match")]
        public string ConfirmPassword { get; set; }
    }
}
