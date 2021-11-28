using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication71.Models
{
    public class UserMockService : IUserRepository
    {

        private static List<User> users;
        private int count = 3;

        public UserMockService()
        {
            users = new List<User>()
            {

                new User() { Id = 1, FirstName = "Mark", LastName = "Paul", Email = "mark.paul@gmail.com", Password = "whatsapp123" },
                new User() { Id = 2, FirstName = "John", LastName = "Lenon", Email = "john.lenon@gmail.com", Password = "user123" },
                new User() { Id = 3, FirstName = "Sherine", LastName = "George", Email = "sherry.george@gmail.com", Password = "myname123" }

            };
        }
        public User AddUser(User user)
        {
            user.Id = ++count;
            users.Add(user);
            return user;
        }

        public void DeleteUser(int id)
        {
            User user = GetUserByID(id);
            users.Remove(user);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetUserByID(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public bool UpdateUser(User user)
        {

            int index = users.FindIndex(c => c.Id == user.Id);
            if (index == -1)
            {
                return false;

            }
            users.RemoveAt(index);
            users.Add(user);
            return true;
        }
    }
}
