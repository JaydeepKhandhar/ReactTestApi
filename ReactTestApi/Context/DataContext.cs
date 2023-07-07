using Microsoft.EntityFrameworkCore;
using ReactTestApi.Models;

namespace ReactTestApi.Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) 
		{
			
		}
		public DbSet<Department> Department { get; set; }
		public DbSet<Employee> Employee { get; set; }
	}
}
