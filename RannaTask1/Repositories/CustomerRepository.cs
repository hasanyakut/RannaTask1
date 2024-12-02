using RannaTask1.Data;
using RannaTask1.Models;

namespace RannaTask1.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDbContext _dbContext;

		public CustomerRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void AddCustomer(Customer customer)
		{
			_dbContext.Customers.Add(customer);
			_dbContext.SaveChanges();
		}

		public bool CustomerExists(string username)
		{
			return _dbContext.Customers.Any(c => c.Username == username);
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return _dbContext.Customers.ToList();
		}

		public Customer? GetCustomerById(int id)
		{
			return _dbContext.Customers.Find(id);
		}

		public void UpdateCustomer(Customer customer)
		{
			_dbContext.Customers.Update(customer);
			_dbContext.SaveChanges();
		}

		public void DeleteCustomer(int id)
		{
			var customer = _dbContext.Customers.Find(id);
			if (customer != null)
			{
				_dbContext.Customers.Remove(customer);
				_dbContext.SaveChanges();
			}
		}
	}
}
