using System.ComponentModel.DataAnnotations;
namespace C__Advanced_Final_Project.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(255)]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
