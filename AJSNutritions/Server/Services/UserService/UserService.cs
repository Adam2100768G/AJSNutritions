using AJSNutritions.Server.Data;
using AJSNutritions.Server.Models;
using AJSNutritions.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AJSNutritions.Server.Services.UserService;

public class UserService : IUserService
{ 
	private readonly ApplicationDbContext _context;
	private readonly UserManager<ApplicationUser> _userManager;

	public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
	{
		_context = context;
		_userManager = userManager;
	}

	public async Task<List<User>> GetUsers()
	{
		return await _context.Users.ToListAsync();
	}

	public async Task<User?> GetUserById(int id)
	{
		var user = await _context.Users.FindAsync(id);
		return user;
	}

	public async Task<User?> GetByUserName(string userName)
	{	// Get the application user by username
		var user = await _userManager.FindByNameAsync(userName);
		if (user == null)
		{
			return null;
		}
		// Get the user ID from the user
		var userId = user.UserId;

		if (userId == null)
		{	// no user ID found, so create a user and assign
			User created = await CreateUser(new User
			{
				CreatedBy = "System",
				DateCreated = DateTime.Now,	
				UserName = "",
				FirstName = "",
				LastName = "",
				Address = "",
				Gender = 0,
				Weight = 0,
				Height = 0,
				Allergies = "",
				TargetWeight = 0,
				TargetBmi = 0,
				ActivityRate = "",
				MedicalHistory = "",
				Bmi = 0,
				
			});
			// assign the user ID to the application user
			user.UserId = created.Id;
			// update the application user
			await _userManager.UpdateAsync(user);

			return created;
		}
		else
		{
			return await _context.Users.FindAsync(userId);
		}
	}

	public async Task<User> CreateUser(User user)
	{
		try
		{
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

	public async Task<User> UpdateUser(int id, User user)
	{
		var toUpdate = await _context.Users.FindAsync(id);
		if (toUpdate == null)
		{
			return null;
		}
		toUpdate.FirstName = user.FirstName;
		toUpdate.LastName = user.LastName;
		toUpdate.DateOfBirth = user.DateOfBirth;
		toUpdate.UserName = user.UserName;
		toUpdate.Address = user.Address;
		toUpdate.Weight = user.Weight;
		toUpdate.Bmi = user.Bmi;
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
}