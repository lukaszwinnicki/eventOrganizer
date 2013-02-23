using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Models;
using EventOrganizer.Web.Services.Abstract;

namespace EventOrganizer.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public bool CanAuthorize(string email, string password)
        {
            var user = _userRepository.GetUserByEmail(email);
            return user != null && string.Equals(user.Password, password);
        }

        public bool IsEmailAvailable(string email)
        {
            return _userRepository.GetUserByEmail(email) == null;
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public User GetUser(long id)
        {
            return _userRepository.GetById(id);
        }
    }
}