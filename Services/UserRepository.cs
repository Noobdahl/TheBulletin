using System.Collections.Generic;
using System.Linq;
using TheBulletin.Data;
using TheBulletin.Models;

namespace TheBulletin.Services
{
    internal class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        //Get all users
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        //Get one user
        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public User? GetUserByName(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }

        //Create user
        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        //Update user???


        //delete user
        public void RemoveUser(User userToRemove)
        {
            _context.Users.Remove(userToRemove);
        }



        //Loginauth
        public User? LoginAuth(string inputName, string inputPassword)
        {
            return _context.Users.FirstOrDefault(u => u.Name == inputName && u.Password == inputPassword);
        }
    }
}
