using System;
using System.Collections.Generic;
using System.Linq;
using EventOrganizer.Web.Models;

namespace EventOrganizer.Web.Services
{
    public class UserService
    {
        public static List<User> Users = new List<User>
            {
                new User
                    {
                        Id = "111",
                        Email = "bj@gy.com",
                        Password = "aaa",
                        PhotoUrl = "/Content/Images/bejdzi.jpg",
                        Name = "Paweł",
                        Surname = "Bejger"
                    }
            };

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public bool CanAuthorize(string email, string password)
        {
            return Users.Any(x => string.Equals(x.Email, email, StringComparison.InvariantCultureIgnoreCase)
                                  && string.Equals(x.Password, password));
        }

        public bool IsEmailAvailable(string email)
        {
            return Users.All(user => !string.Equals(email, user.Email, StringComparison.InvariantCultureIgnoreCase));
        }

        public User GetUser(string id)
        {
            return Users.Single(u => string.Equals(u.Id, id, StringComparison.InvariantCulture));
        }

        public User GetUserByEmail(string email)
        {
            return Users.Single(u => string.Equals(u.Email, email, StringComparison.InvariantCulture));
        }
    }
}