using RannaTask1.Models;

namespace RannaTask1.Services
{
	public interface ISupportFormService
	{
		void CreateSupportForm(SupportForm form);
		IEnumerable<SupportForm> GetAllSupportForms();
		void UpdateSupportForm(int id, SupportForm form);
		void DeleteSupportForm(int id);
	}
}
