using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
	public class RequestTrackerContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=C1RBBX3\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbEmployeeTrackerCF;");
		}
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Request> Requests { get; set; }
	}
}
