using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Client.Services.StaffService
{
    public interface IStaffService
	{
		List<Staff> Staffs { get; set; }

		Task GetStaffs();

		Task<Staff?> GetStaffById(int id);

		Task<Staff?> CreateStaff(Staff staff);

		Task<Staff?> UpdateStaff(int id, Staff staff);

		Task DeleteStaff(int id);
	}
}
