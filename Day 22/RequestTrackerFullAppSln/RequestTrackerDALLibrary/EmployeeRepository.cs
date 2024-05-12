using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(RequestTrackerContext context) : base(context)
        {
        }
    }
}
