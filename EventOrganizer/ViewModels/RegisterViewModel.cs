using System.ComponentModel.DataAnnotations;

namespace EventOrganizer.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name = "Retype password")]
        public string RePassword { get; set; }
        public bool Remember { get; set; }
    }
}