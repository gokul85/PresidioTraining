using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestService
    {
        public Task<Request> RaiseRequest(string request,int userid);
        public Task<IEnumerable<Request>> GetAllRequests(int? userid);
    }
}
