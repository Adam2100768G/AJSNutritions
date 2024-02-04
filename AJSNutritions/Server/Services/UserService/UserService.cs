using AJSNutritions.Server.Data;
using AJSNutritions.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace AJSNutritions.Server.Services.UserService;

// Server side CRUD implementation for User
public class UserService : IUserService
{ 
	private readonly ApplicationDbContext _context;
	
	public UserService(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<List<User>> GetUsers()
	{
		return await _context.Users.ToListAsync();
	}

	public async Task<User?> GetUserById(int id)
	{
		return await _context.Users.FindAsync(id);
	}

	public async Task<User> CreateUser(User user)
	{
		try
		{
			// Update the BMI before saving
			user.Bmi = CalculateBmi(user);
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
			return user;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	public async Task<User?> UpdateUser(int id, User user)
	{
		var toUpdate = await _context.Users.FindAsync(id);
		if (toUpdate == null)
		{
			return null;
		}
		toUpdate.FirstName = user.FirstName;
		toUpdate.LastName = user.LastName;
		toUpdate.DateOfBirth = user.DateOfBirth;
		toUpdate.Address = user.Address;
		toUpdate.Weight = user.Weight;
		// Update the BMI before saving
		toUpdate.Bmi = CalculateBmi(user);
		toUpdate.Height = user.Height;
		toUpdate.Gender = user.Gender;
		toUpdate.ActivityRate = user.ActivityRate;
		toUpdate.MedicalHistory = user.MedicalHistory;
		toUpdate.TargetDate = user.TargetDate;
		toUpdate.TargetWeight = user.TargetWeight;
		toUpdate.TargetBmi = user.TargetBmi;
		toUpdate.UpdatedBy = user.UpdatedBy;
		toUpdate.DateUpdated = user.DateUpdated;
		toUpdate.DateCreated = user.DateCreated;
		toUpdate.CreatedBy = user.CreatedBy;

		await _context.SaveChangesAsync();

		return toUpdate;
	}

	public async Task<bool> DeleteUser(int id)
	{
		var user = await _context.Users.FindAsync(id);
		if (user == null)
		{
			return false;
		}

		_context.Users.Remove(user);
		await _context.SaveChangesAsync();

		return true;
	}

	// Calculate BMI assuming weight is in kg and height is in cm
	// BMI = weight / (height / 100)^2
	// Take care of division by zero
	private double CalculateBmi(User user)
	{
		double heightCm = user.Height ?? 0;
		double weight = user.Weight ?? 0;

		if (heightCm <= 0 || weight <= 0)
		{
			return 0;
		}

		return weight / Math.Pow(heightCm / 100.0, 2);
	}
}