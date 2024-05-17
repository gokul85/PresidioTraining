using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestservice;

        public RequestController(IRequestService service)
        {
            _requestservice = service;
        }

        [HttpGet("GetRequestUser")]
        [Authorize]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Request>>> GetRequestsUser()
        {
            try
            {
                int userid = int.Parse(User.FindFirst("eid").Value);
                var requests = await _requestservice.GetAllRequests(userid);
                return Ok(requests.ToList());
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [HttpGet("GetRequestAdmin")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(IList<Request>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<IList<Request>>> GetRequestsAdmin()
        {
            try
            {
                var requests = await _requestservice.GetAllRequests(null);
                return Ok(requests.ToList());
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }

        [HttpPost("RaiseRequest")]
        [Authorize]
        [ProducesResponseType(typeof(Request), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(ErrorModel))]
        public async Task<ActionResult<Request>> Get([FromBody]string requestmessage)
        {
            try
            {
                int userid = int.Parse(User.FindFirst("eid").Value);
                var result = await _requestservice.RaiseRequest(requestmessage,userid);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
