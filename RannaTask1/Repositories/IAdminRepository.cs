using RannaTask1.Models;

namespace RannaTask1.Repositories
{
	public interface IAdminRepository
	{
		void AddAdmin(Admin admin);
		bool AdminExists(string username);
		IEnumerable<Admin> GetAllAdmins();
		Admin? GetAdminById(int id);
		void UpdateAdmin(Admin admin);
		void DeleteAdmin(int id);
	}
}
