using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
namespace RequestTrackerBLLibrary
{
    public class RequestTrackerService
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly RequestRepository _requestRepository;
        private readonly RequestSolutionRepository _requestSolutionRepository;
        private readonly SolutionFeedbackRepository _solutionFeedbackRepository;

        public RequestTrackerService(EmployeeRepository employeeRepository,
            RequestRepository requestRepository,
            RequestSolutionRepository requestSolutionRepository,
            SolutionFeedbackRepository solutionFeedbackRepository)
        {
            _employeeRepository = employeeRepository;
            _requestRepository = requestRepository;
            _requestSolutionRepository = requestSolutionRepository;
            _solutionFeedbackRepository = solutionFeedbackRepository;
        }

        // User Actions
        public async Task RaiseRequest(string requestmsg,int employeeid)
        {
            Request request = new Request() { RequestMessage = requestmsg, RequestStatus = "Pending", RequestRaisedBy = employeeid };
            await _requestRepository.AddAsync(request);
        }

        public async Task<Employee> GetUserByUsernameAndPasswordAsync(string username,string password)
        {
            List<Employee> employees = await _employeeRepository.FindAsync(e => e.Username == username);
            if (employees.Count == 0 || employees[0].Password != password )
                return null;
            return employees[0];
        }

        public async Task<List<Request>> GetUserRequestsAsync(int userId)
        {
            return await _requestRepository.FindAsync(r => r.RequestRaisedBy == userId);
        }

        public async Task<List<RequestSolution>> GetRequestSolutionsAsync(int requestId)
        {
            return await _requestSolutionRepository.FindAsync(rs => rs.RequestId == requestId);
        }

        public async Task GiveFeedback(int solutionid,float rating,string remark,int employeeid)
        {
            SolutionFeedback feedback = new SolutionFeedback() { SolutionId = solutionid,Rating = rating,Remarks = remark, FeedbackBy = employeeid,FeedbackDate = System.DateTime.Now};
            await _solutionFeedbackRepository.AddAsync(feedback);
        }

        public async Task RespondToSolution(int solutionid,string comment)
        {
            var solution = await _requestSolutionRepository.GetByIdAsync(solutionid);
            if (solution == null)
            {
                throw new InvalidOperationException("Solution not found.");
            }
            solution.RequestRaiserComment = comment;
            await _requestSolutionRepository.UpdateAsync(solution);
        }

        // Admin Actions
        public async Task<List<Request>> GetAllRequestsAsync()
        {
            return await _requestRepository.GetAllAsync();
        }

        public async Task<List<RequestSolution>> GetAllSolutionsAsync()
        {
            return await _requestSolutionRepository.GetAllAsync();
        }

        public async Task ProvideSolution(int requestid, string solutionmsg,int employeeid)
        {
            RequestSolution solution= new RequestSolution() { RequestId = requestid, SolutionDescription = solutionmsg, SolvedDate = System.DateTime.Now,SolvedBy=employeeid };
            await _requestSolutionRepository.AddAsync(solution);
        }

        public async Task<List<SolutionFeedback>> GetFeedbacksForAdminAsync(int adminId)
        {
            return await _solutionFeedbackRepository.FindAsync(sf => sf.Solution.RequestRaised.RequestRaisedBy == adminId);
        }

        public async Task MarkRequestAsClosed(int requestId)
        {
            var request = await _requestRepository.GetByIdAsync(requestId);
            if (request != null)
            {
                request.RequestStatus = "Closed";
                request.ClosedDate = DateTime.Now;
                await _requestRepository.UpdateAsync(request);
            }
        }
    }
}
