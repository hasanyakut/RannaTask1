using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RannaTask1.Requests;
using RannaTask1.Services;

namespace RannaTask1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpPost("register")]
		public IActionResult Register([FromBody] CustomerRequest request)
		{
			try
			{
				_customerService.RegisterCustomer(request);
				return Ok("Customer registered successfully");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Authorize]
		public IActionResult GetAll()
		{
			var customers = _customerService.GetAllCustomers();
			return Ok(customers);
		}

		[HttpPut("{id}")]
		[Authorize]
		public IActionResult UpdateCustomer(int id, [FromBody] CustomerRequest request)
		{
			try
			{
				_customerService.UpdateCustomer(id, request);
				return Ok("Customer updated successfully");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		[Authorize]
		public IActionResult DeleteCustomer(int id)
		{
			try
			{
				_customerService.DeleteCustomer(id);
				return Ok("Customer deleted successfully");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
