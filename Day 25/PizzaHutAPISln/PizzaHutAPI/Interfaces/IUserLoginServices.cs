using PizzaHutAPI.Models;
using PizzaHutAPI.Models.DTOs;

namespace PizzaHutAPI.Interfaces
{
    public interface IUserLoginServices
    {
        public Task<User> Login(UserLoginDTO loginDTO);
        public Task<User> Register(UserDTO userDTO);
    }
}
