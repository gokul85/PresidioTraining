using Microsoft.EntityFrameworkCore;

namespace SampleAPI
{
    public class WeatherAppContext : DbContext
    {
        public WeatherAppContext(DbContextOptions options) : base(options) { }
    }
}
