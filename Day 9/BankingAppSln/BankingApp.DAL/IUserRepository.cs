using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.DAL
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(string username);
        User GetUserById(int id);
        void UpdateUser(User user);
        int GetUserCount();

    }
}
