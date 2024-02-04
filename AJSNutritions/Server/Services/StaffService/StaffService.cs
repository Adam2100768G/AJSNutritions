using AJSNutritions.Server.Data;
using AJSNutritions.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace AJSNutritions.Server.Services.StaffService;

// Server side CRUD implementation for Staff
public class StaffService : IStaffService
{
	private readonly ApplicationDbContext _context;
	
	public StaffService(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<List<Staff>> GetStaffs()
	{
		return await _context.Staffs.ToListAsync();
	}

	public async Task<Staff?> GetStaffById(int id)
	{
		return await _context.Staffs.FindAsync(id);
	}

	public async Task<Staff> CreateStaff(Staff staff)
	{
		_context.Staffs.Add(staff);
		await _context.SaveChangesAsync();
		return staff;
	}

	public async Task<Staff> UpdateStaff(int id, Staff staff)
	{
		var toUpdate = await _context.Staffs.FindAsync(id);
		if (toUpdate == null)
		{
			return null;
		}
		toUpdate.Name = staff.Name;
		toUpdate.Email = staff.Email;
		toUpdate.DateOfBirth = staff.DateOfBirth;
		toUpdate.Password = staff.Password;
		toUpdate.Gender = staff.Gender;
		toUpdate.Address = staff.Address;
		toUpdate.Phone = staff.Phone;
		toUpdate.StaffType = staff.StaffType;
		toUpdate.UpdatedBy = staff.UpdatedBy;
		toUpdate.DateUpdated = staff.DateUpdated;
		toUpdate.DateCreated = staff.DateCreated;
		toUpdate.CreatedBy = staff.CreatedBy;

		await _context.SaveChangesAsync();

		return toUpdate;
	}

	public async Task<bool> DeleteStaff(int id)
	{
		var staff = await _context.Staffs.FindAsync(id);
		if (staff == null)
		{
			return false;
		}

		_context.Staffs.Remove(staff);
		await _context.SaveChangesAsync();

		return true;
	}
}

