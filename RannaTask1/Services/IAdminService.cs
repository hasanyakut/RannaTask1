using RannaTask1.Requests;
using RannaTask1.Models;

namespace RannaTask1.Services
{
	public interface IAdminService
	{
		void RegisterAdmin(AdminRequest request);
		IEnumerable<Admin> GetAllAdmins();
		Admin? GetAdminById(int id);
		void UpdateAdmin(int id, AdminRequest request);
		void DeleteAdmin(int id); 
	}
}
