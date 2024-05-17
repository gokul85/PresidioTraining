using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly IReposiroty<int, Request> _reqrepo;
        public RequestService(IReposiroty<int, Request> reqrepo)
        {
            _reqrepo = reqrepo;
        }
        public async Task<IEnumerable<Request>> GetAllRequests(int? userid)
        {
            var requests = await _reqrepo.Get();
            if (requests.Any())
            {
                if(userid != null)
                {
                    return requests.Where(r=>r.RequestRaisedBy == userid && r.RequestStatus != "Closed").ToList();
                }
                return requests.Where(r => r.RequestStatus != "Closed").ToList();
            }
            throw new Exception("No Request Found");
        }

        public async Task<Request> RaiseRequest(string requestmsg, int userid)
        {
            Request requset = new Request() { RequestMessage = requestmsg, RequestRaisedBy = userid, RequestStatus = "Pending" };
            var result = await _reqrepo.Add(requset);
            return result;
        }
    }
}
