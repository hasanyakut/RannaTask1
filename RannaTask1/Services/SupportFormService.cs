using RannaTask1.Models;
using RannaTask1.Repositories;

namespace RannaTask1.Services
{
	public class SupportFormService : ISupportFormService
	{
		private readonly ISupportFormRepository _supportFormRepository;

		public SupportFormService(ISupportFormRepository supportFormRepository)
		{
			_supportFormRepository = supportFormRepository;
		}

		public void CreateSupportForm(SupportForm form)
		{
			_supportFormRepository.AddSupportForm(form);
		}

		public IEnumerable<SupportForm> GetAllSupportForms()
		{
			return _supportFormRepository.GetAllSupportForms();
		}

		public void UpdateSupportForm(int id, SupportForm form)
		{
			var existingForm = _supportFormRepository.GetSupportFormById(id);
			if (existingForm == null)
				throw new Exception("Form not found");

			existingForm.Subject = form.Subject;
			existingForm.Message = form.Message;
			existingForm.Status = form.Status;
			_supportFormRepository.UpdateSupportForm(existingForm);
		}

		public void DeleteSupportForm(int id)
		{
			if (!_supportFormRepository.DeleteSupportForm(id))
				throw new Exception("Form not found");
		}
	}
}
