using RannaTask1.Data;
using RannaTask1.Models;

namespace RannaTask1.Repositories
{
	public class SupportFormRepository : ISupportFormRepository
	{
		private readonly AppDbContext _dbContext;

		public SupportFormRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void AddSupportForm(SupportForm form)
		{
			_dbContext.SupportForms.Add(form);
			_dbContext.SaveChanges();
		}

		public IEnumerable<SupportForm> GetAllSupportForms()
		{
			return _dbContext.SupportForms.ToList();
		}

		public SupportForm? GetSupportFormById(int id)
		{
			return _dbContext.SupportForms.Find(id);
		}

		public void UpdateSupportForm(SupportForm form)
		{
			_dbContext.SupportForms.Update(form);
			_dbContext.SaveChanges();
		}

		public bool DeleteSupportForm(int id)
		{
			var form = _dbContext.SupportForms.Find(id);
			if (form == null) return false;

			_dbContext.SupportForms.Remove(form);
			_dbContext.SaveChanges();
			return true;
		}
	}
}
