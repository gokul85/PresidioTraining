using PizzaHutAPIWithAuth.Models;

namespace PizzaHutAPIWithAuth.Interfaces
{
    public interface ITokenService
    {
        public string GenerateJWTToken(User user);
    }
}
