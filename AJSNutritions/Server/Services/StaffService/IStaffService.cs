using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Server.Services.StaffService
{
	public interface IStaffService
	{
		Task<List<Staff>> GetStaffs();

		Task<Staff?> GetStaffById(int id);

		Task<Staff> CreateStaff(Staff staff);

		Task<Staff> UpdateStaff(int id, Staff staff);

		Task<bool> DeleteStaff(int id);
	}
}
