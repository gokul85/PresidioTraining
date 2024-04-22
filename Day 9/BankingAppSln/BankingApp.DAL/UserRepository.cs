using System.Numerics;
using BankingApp.Models;

namespace BankingApp.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        public UserRepository()
        {
            _users = new List<User>();
        }
        public void AddUser(User user)
        {
            _users.Add(user);
        }
        public User GetUser(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }
        public User GetUserById(int Id)
        {
            return _users.FirstOrDefault(u => u.Id == Id);
        }
        public void UpdateUser(User user)
        {
            var index = _users.FindIndex(u => u.Id == user.Id);
            _users[index] = user;
        }
        public int GetUserCount()
        {
            return _users.Count;
        }
    }
}
