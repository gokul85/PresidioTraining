using PizzaHutAPIWithAuth.Exceptions;
using PizzaHutAPIWithAuth.Interfaces;
using PizzaHutAPIWithAuth.Models;
using PizzaHutAPIWithAuth.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaHutAPIWithAuth.Services
{
    public class UserServices : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, UserDetails> _userdetailsRepo;
        private readonly ITokenService _tokenService;
        public UserServices(IRepository<int, User> userrepo, IRepository<int, UserDetails> userdetailsrepo, ITokenService tokenService)
        {
            _userRepo = userrepo;
            _userdetailsRepo = userdetailsrepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO userLoginDTO)
        {
            var UserExist = await _userdetailsRepo.FindAsync(ud => ud.Username == userLoginDTO.Username);
            if (UserExist.Any())
            {
                var userDetails = UserExist.First();
                HMACSHA512 hMACSHA512 = new HMACSHA512(userDetails.PasswordHashKey);
                var encryptedpass = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(userLoginDTO.Password));
                if (ComparePassword(encryptedpass, userDetails.Password))
                {
                    if (userDetails.Status == "Active")
                    {
                        var userDb = await _userRepo.Get(userDetails.UserId);
                        LoginReturnDTO loginReturnDTO = MapLoginReturnDTOToUser(userDb, userDetails);
                        return loginReturnDTO;
                    }
                    throw new UserNotActive("User is not active");
                }
                throw new UnauthorizedUserException("Invalid Username or password");
            }
            throw new UnauthorizedUserException("Invalid Username or password");
        }

        private LoginReturnDTO MapLoginReturnDTOToUser(User userDb, UserDetails userDetails)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.UserId = userDb.Id;
            returnDTO.Role = userDb.Role ?? "User";
            returnDTO.Username = userDetails.Username;
            returnDTO.Token = _tokenService.GenerateJWTToken(userDb);
            return returnDTO;
        }

        private bool ComparePassword(byte[] encryptedpass, byte[] password)
        {
            for (int i = 0; i < encryptedpass.Length; i++)
            {
                if (encryptedpass[i] != password[i])
                    return false;
            }
            return true;
        }

        public async Task<User> Register(UserRegisterDTO userRegisterDTO)
        {
            var UserExist = await _userdetailsRepo.FindAsync(ud => ud.Username == userRegisterDTO.Username);
            if (UserExist.Any())
            {
                throw new UsernameAlreadyExsistException("Username already exist");
            }
            User user = null;
            UserDetails userDetails = null;
            try
            {
                user = userRegisterDTO;
                userDetails = MapUserRegisterDTOToUserDetails(userRegisterDTO);
                user = await _userRepo.Add(user);
                userDetails.UserId = user.Id;
                userDetails = await _userdetailsRepo.Add(userDetails);
                ((UserRegisterDTO)user).Password = String.Empty;
                return user;
            }
            catch (Exception ex) { }
            if (user != null)
                RevertUserInsert(user);
            if(userDetails != null && user != null)
                RevertUserDetailsInserted(userDetails);
            throw new UnableToRegisterException("Unable to register at this moment");
        }

        private async void RevertUserDetailsInserted(UserDetails userDetails)
        {
            await _userdetailsRepo.Delete(userDetails.UserId);
        }

        private async void RevertUserInsert(User user)
        {
            await _userRepo.Delete(user.Id);
        }

        private UserDetails MapUserRegisterDTOToUserDetails(UserRegisterDTO userRegisterDTO)
        {
            UserDetails ud = new UserDetails();
            ud.Username = userRegisterDTO.Username;
            HMACSHA512 hMACSHA512 = new HMACSHA512();
            ud.PasswordHashKey = hMACSHA512.Key;
            ud.Password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password));
            ud.Status = "Disabled";
            return ud;
        }

        public async Task<string> UpdateUserStatus(UserUpdateStatusDTO userUpdateStatusDTO)
        {
            UserDetails ud = await _userdetailsRepo.Get(userUpdateStatusDTO.UserId);
            if(ud != null)
            {
                ud.Status = userUpdateStatusDTO.Status;
                await _userdetailsRepo.Update(ud);
                return "User Status Successfully Updated";
            }
            throw new UserNotFoundException("User Details Not Found");
        }
    }
}
