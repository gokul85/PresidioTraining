using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository : BaseRepository<RequestSolution>
    {
        public RequestSolutionRepository(RequestTrackerContext context) : base(context)
        {
        }
    }
}
