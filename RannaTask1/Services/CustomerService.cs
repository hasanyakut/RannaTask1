using RannaTask1.Models;
using RannaTask1.Repositories;
using RannaTask1.Requests;

namespace RannaTask1.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public void RegisterCustomer(CustomerRequest request)
		{
			if (_customerRepository.CustomerExists(request.Username))
				throw new Exception("Customer already exists");

			var customer = new Customer
			{
				Username = request.Username,
				Password = request.Password 
			};

			_customerRepository.AddCustomer(customer);
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return _customerRepository.GetAllCustomers();
		}

		public Customer? GetCustomerById(int id)
		{
			return _customerRepository.GetCustomerById(id);
		}

		public void UpdateCustomer(int id, CustomerRequest request)
		{
			var customer = _customerRepository.GetCustomerById(id);
			if (customer == null)
				throw new Exception("Customer not found");

			customer.Username = request.Username;
			customer.Password = request.Password;
			_customerRepository.UpdateCustomer(customer);
		}

		public void DeleteCustomer(int id)
		{
			if (_customerRepository.GetCustomerById(id) == null)
				throw new Exception("Customer not found");

			_customerRepository.DeleteCustomer(id);
		}
	}
}
