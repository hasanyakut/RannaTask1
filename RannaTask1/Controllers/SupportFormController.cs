using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RannaTask1.Models;
using RannaTask1.Requests;
using RannaTask1.Services;

namespace RannaTask1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupportFormController : ControllerBase
	{
		private readonly ISupportFormService _supportFormService;

		public SupportFormController(ISupportFormService supportFormService)
		{
			_supportFormService = supportFormService;
		}

		[HttpPost("create")]
		[Authorize]
		public IActionResult CreateForm([FromBody] SupportFormRequest request)
		{
			try
			{
				var newForm = new SupportForm
				{
					Subject = request.Subject,
					Message = request.Message,
					CreatedAt = DateTime.UtcNow,
					Status = "Pending"
				};

				_supportFormService.CreateSupportForm(newForm);
				return Ok(new { Success = true});
			}
			catch (Exception ex)
			{
				return BadRequest(new { Success = false, Message = ex.Message });
			}
		}

		[HttpGet]
		[Authorize]
		public IActionResult GetForms()
		{
			var forms = _supportFormService.GetAllSupportForms();
			return Ok(forms);
		}

		[HttpPut("{id}")]
		[Authorize]
		public IActionResult UpdateForm(int id, [FromBody] SupportForm form)
		{
			try
			{
				_supportFormService.UpdateSupportForm(id, form);
				return Ok(new { Success = true});
			}
			catch (Exception ex)
			{
				return BadRequest(new { Success = false, Message = ex.Message });
			}
		}

		[HttpDelete("{id}")]
		[Authorize]
		public IActionResult DeleteForm(int id)
		{
			try
			{
				_supportFormService.DeleteSupportForm(id);
				return Ok(new { Success = true});
			}
			catch (Exception ex)
			{
				return BadRequest(new { Success = false, Message = ex.Message });
			}
		}
	}
}
