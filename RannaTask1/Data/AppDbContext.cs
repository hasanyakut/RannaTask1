using Microsoft.EntityFrameworkCore;
using RannaTask1.Models;

namespace RannaTask1.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Admin> Admins { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<SupportForm> SupportForms { get; set; }


	}

}
