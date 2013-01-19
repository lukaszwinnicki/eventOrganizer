namespace EventOrganizer.ViewModels
{
    public class IndexViewModel
    {
        public RegisterViewModel RegistrationViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }

        public IndexViewModel()
        {
            RegistrationViewModel = new RegisterViewModel();
            LoginViewModel = new LoginViewModel();
        }
    }
}