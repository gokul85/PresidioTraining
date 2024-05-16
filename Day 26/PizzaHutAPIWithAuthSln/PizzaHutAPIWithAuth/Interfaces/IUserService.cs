using PizzaHutAPIWithAuth.Models;
using PizzaHutAPIWithAuth.Models.DTOs;

namespace PizzaHutAPIWithAuth.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO userLoginDTO);
        public Task<User> Register(UserRegisterDTO userRegisterDTO);
    }
}
