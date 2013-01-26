using System.ComponentModel.DataAnnotations;

namespace EventOrganizer.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}