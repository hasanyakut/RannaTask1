using RannaTask1.Data;
using RannaTask1.Models;

namespace RannaTask1.Repositories
{
	public class AdminRepository : IAdminRepository
	{
		private readonly AppDbContext _dbContext;

		public AdminRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public void AddAdmin(Admin admin)
		{
			_dbContext.Admins.Add(admin);
			_dbContext.SaveChanges();
		}

		public bool AdminExists(string username)
		{
			return _dbContext.Admins.Any(a => a.Username == username);
		}

		public IEnumerable<Admin> GetAllAdmins()
		{
			return _dbContext.Admins.ToList();
		}

		public Admin? GetAdminById(int id)
		{
			return _dbContext.Admins.Find(id);
		}

		public void UpdateAdmin(Admin admin)
		{
			_dbContext.Admins.Update(admin);
			_dbContext.SaveChanges();
		}

		public void DeleteAdmin(int id)
		{
			var admin = _dbContext.Admins.Find(id);
			if (admin != null)
			{
				_dbContext.Admins.Remove(admin);
				_dbContext.SaveChanges();
			}
		}
	}
}
