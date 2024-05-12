using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : BaseRepository<Request>
    {
        public RequestRepository(RequestTrackerContext context) : base(context)
        {
        }
    }
}
