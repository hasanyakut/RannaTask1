using RannaTask1.Models;

namespace RannaTask1.Repositories
{
	public interface ICustomerRepository
	{
		void AddCustomer(Customer customer);
		bool CustomerExists(string username);
		IEnumerable<Customer> GetAllCustomers();
		Customer? GetCustomerById(int id);
		void UpdateCustomer(Customer customer); 
		void DeleteCustomer(int id);
	}
}
