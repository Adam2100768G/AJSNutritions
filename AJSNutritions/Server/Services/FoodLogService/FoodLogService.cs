using AJSNutritions.Server.Data;
using AJSNutritions.Server.Models;
using AJSNutritions.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AJSNutritions.Server.Services.FoodLogService;

public class FoodLogService : IFoodLogService
{
	private readonly ApplicationDbContext _context;
	private readonly UserManager<ApplicationUser> _userManager;

	public FoodLogService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
	{
		_context = context;
		_userManager = userManager;
	}

	public async Task<List<FoodLogging>> GetFoodLogs(string userName)
	{
		// get the userId for the given userName
		ApplicationUser? user = await GetUserByName(userName);

		if (user == null)
		{
			throw new ApplicationException("User not found");
		}

		return await _context.FoodLogs
			.Where(fl => fl.ApplicationUserId == user.Id) // Get all the food logs for the user
			.Select(fl => new FoodLogging					// create a DTO to return
			{
				Id = fl.Id,
				Date = fl.Date,
			}).ToListAsync();
	}

	public async Task<FoodLogging?> GetFoodLogById(int id)
	{
		var foodLog = await _context.FoodLogs.FindAsync(id);

		if (foodLog == null)
		{
			return null;
		}
		ApplicationUser? user = await GetUserById(foodLog.ApplicationUserId);

		if (user == null)
		{
			return null;
		}

		return new FoodLogging
		{
			Id = foodLog.Id,
			Date = foodLog.Date,
		};
	}

	public async Task<FoodLogging> CreateFoodLog(FoodLogging foodLogDto)
	{
		// get the user
		ApplicationUser user = await GetUserByName(foodLogging.);

		if (user == null)
		{
			throw new ApplicationException("User not found");
		}

		var foodLog = new FoodLog
		{
			Date = foodLogDto.Date,
			ApplicationUserId = user.Id,
		};

		_context.FoodLogs.Add(foodLog);
		await _context.SaveChangesAsync();

		foodLogDto.Id = foodLog.Id;

		return foodLogDto;
	}

	public async Task<FoodLogging> UpdateFoodLog(int id, FoodLogging foodLogDto)
	{
		return null;
	}

	public async Task<bool> DeleteFoodLog(int id)
	{
		var foodLog = await _context.FoodLogs.FindAsync(id);
		if (foodLog == null)
		{
			return false;
		}

		_context.FoodLogs.Remove(foodLog);
		await _context.SaveChangesAsync();

		return true;
	}

	private async Task<ApplicationUser?> GetUserByName(string userName)
	{
		var user = await _userManager.FindByNameAsync(userName);

		if (user == null)
		{
			return null;
		}

		return user;
	}
	
	private async Task<ApplicationUser?> GetUserById(string id)
	{
		var user = await _userManager.FindByIdAsync(id);

		if (user == null)
		{
			return null;
		}

		return user;
	}
}