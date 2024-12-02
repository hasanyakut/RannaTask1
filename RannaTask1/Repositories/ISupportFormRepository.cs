using RannaTask1.Models;

namespace RannaTask1.Repositories
{
	public interface ISupportFormRepository
	{
		void AddSupportForm(SupportForm form);
		IEnumerable<SupportForm> GetAllSupportForms();
		SupportForm? GetSupportFormById(int id);
		void UpdateSupportForm(SupportForm form);
		bool DeleteSupportForm(int id);
	}
}
