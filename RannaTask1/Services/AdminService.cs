using RannaTask1.Models;
using RannaTask1.Repositories;
using RannaTask1.Requests;

namespace RannaTask1.Services
{
	public class AdminService : IAdminService
	{
		private readonly IAdminRepository _adminRepository;

		public AdminService(IAdminRepository adminRepository)
		{
			_adminRepository = adminRepository;
		}

		public void RegisterAdmin(AdminRequest request)
		{
			if (_adminRepository.AdminExists(request.Username))
				throw new Exception("Admin already exists");

			var admin = new Admin
			{
				Username = request.Username,
				Password = request.Password 
			};

			_adminRepository.AddAdmin(admin);
		}

		public IEnumerable<Admin> GetAllAdmins()
		{
			return _adminRepository.GetAllAdmins();
		}

		public Admin? GetAdminById(int id)
		{
			return _adminRepository.GetAdminById(id);
		}

		public void UpdateAdmin(int id, AdminRequest request)
		{
			var admin = _adminRepository.GetAdminById(id);
			if (admin == null)
				throw new Exception("Admin not found");

			admin.Username = request.Username;
			admin.Password = request.Password; 
			_adminRepository.UpdateAdmin(admin);
		}

		public void DeleteAdmin(int id) 
		{
			var admin = _adminRepository.GetAdminById(id);
			if (admin == null)
				throw new Exception("Admin not found");

			_adminRepository.DeleteAdmin(id);
		}
	}
}
