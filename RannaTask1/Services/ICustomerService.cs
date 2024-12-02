using RannaTask1.Models;
using RannaTask1.Requests;

namespace RannaTask1.Services
{
	public interface ICustomerService
	{
		void RegisterCustomer(CustomerRequest request);
		IEnumerable<Customer> GetAllCustomers();
		Customer? GetCustomerById(int id);
		void UpdateCustomer(int id, CustomerRequest request); 
		void DeleteCustomer(int id); 
	}
}
