using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RannaTask1.Requests;
using RannaTask1.Services;

namespace RannaTask1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly IAdminService _adminService;

		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		[HttpPost("register")]
		public IActionResult Register([FromBody] AdminRequest request)
		{
			try
			{
				_adminService.RegisterAdmin(request);
				return Ok("Admin registered successfully");
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
			var admins = _adminService.GetAllAdmins();
			return Ok(admins);
		}

		[HttpDelete("{id}")]
		[Authorize]
		public IActionResult Delete(int id)
		{
			try
			{
				_adminService.DeleteAdmin(id);
				return Ok("Admin deleted successfully");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		[Authorize]
		public IActionResult UpdateAdmin(int id, [FromBody] AdminRequest request)
		{
			try
			{
				_adminService.UpdateAdmin(id, request);
				return Ok("Admin updated successfully");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
