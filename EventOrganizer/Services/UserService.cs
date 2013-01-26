using System.Collections.Generic;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Services
{
    public class UserService
    {
        public static List<User> Users = new List<User>
                                             {
                                                 new User
                                                     {
                                                         Email = "bj@gy.com",
                                                         Password = "aaa"
                                                     }
                                             };
        public void AddUser(User user)
        {
            
        }

        public bool CanAuthorize(string email, string password)
        {
            return false;
        }

        public bool IsEmailAvailable(string email)
        {
            return false;
        }
    }
}