using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class SolutionFeedbackRepository : BaseRepository<SolutionFeedback>
    {
        public SolutionFeedbackRepository(RequestTrackerContext context) : base(context)
        {
        }
    }
}
