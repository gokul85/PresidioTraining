using RequestTrackerAPI.Exceptions;
using RequestTrackerAPI.Interfaces;
using RequestTrackerAPI.Models;
using RequestTrackerAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace RequestTrackerAPI.Services
{
    public class UserServices : IUserService
    {
        private readonly IRepository<int,Employee> _employeeRepository;
        private readonly IRepository<int,User> _userRepository;
        public UserServices(IRepository<int, User> userrepo, IRepository<int, Employee> employeerepo)
        {
            _employeeRepository = employeerepo;
            _userRepository = userrepo;
        }
        public async Task<Employee> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepository.Get(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA512 = new HMACSHA512(userDB.PasswordHashKey);
            var encryptedpass = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            if (ComparePassword(encryptedpass, userDB.Password))
            {
                var employee = await _employeeRepository.Get(loginDTO.UserId);
                if(userDB.Status == "Active")
                {
                    return employee;
                }
                throw new UserNotActiveException("Your Account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        private bool ComparePassword(byte[] encryptedpass, byte[] password)
        {
            for (int i = 0; i < encryptedpass.Length; i++)
            {
                if (encryptedpass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<Employee> Register(EmployeeUserDTO employeeUserDTO)
        {
            Employee employee = null;
            User user = null;
            try
            {
                employee = employeeUserDTO;
                user = MapEmployeeDTOToUser(employeeUserDTO);
                employee = await _employeeRepository.Add(employee);
                user.EmployeeId = employee.Id;
                user = await _userRepository.Add(user);
                ((EmployeeUserDTO)employee).Password = String.Empty;
                return employee;
            }
            catch(Exception){}
            if(employee != null)
                await RevertEmployeeInsert(employee);
            if (user != null && employee != null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepository.Delete(user.EmployeeId);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {
            await _employeeRepository.Delete(employee.Id);
        }

        private User MapEmployeeDTOToUser(EmployeeUserDTO employeeUserDTO)
        {
            User user = new User();
            user.EmployeeId = employeeUserDTO.Id;
            user.Status = "Disabled";
            HMACSHA512 hMACSHA512  = new HMACSHA512();
            user.PasswordHashKey = hMACSHA512.Key;
            user.Password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(employeeUserDTO.Password));
            return user;
        }
    }
}
