using RequestTrackerAPI.Models.DTOs;
using RequestTrackerAPI.Models;

namespace RequestTrackerAPI.Interfaces
{
    public interface IUserService
    {
        public Task<Employee> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeUserDTO);
    }
}
