using Microsoft.AspNetCore.Mvc;
using RequestTrackerAPI.Interfaces;
using RequestTrackerAPI.Models;
using RequestTrackerAPI.Models.DTOs;
using System.Linq.Expressions;

namespace RequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userservice)
        {
            userService = userservice;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(Employee),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Employee>> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var result = await userService.Login(userLoginDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }


        [HttpPost("Register")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Employee>> Register(EmployeeUserDTO employeeUserDTO)
        {
            try
            {
                var result = await userService.Register(employeeUserDTO);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }
    }
}
