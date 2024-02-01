using AJSNutritions.Server.Data;
using AJSNutritions.Server.Models;
using AJSNutritions.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AJSNutritions.Shared.Domain;

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

	public async Task<List<FoodLog>> GetFoodLogs(string userName)
	{
		var user = await _userManager.FindByNameAsync(userName);
		if (user == null)
		{
			return null;
		}
		// Get the user ID from the user
		var userId = user.UserId;

		if (userId == null)
		{
			return new List<FoodLog>();
		}

		return await _context.FoodLogs
			.Where(fl => fl.UserId == userId)		// Get all the food logs for the user
			.Select(fl => new FoodLog					// create a DTO to return
			{
				Id = fl.Id,
				Date = fl.Date,
			}).ToListAsync();
	}

	public async Task<FoodLog?> GetFoodLogById(int id)
	{
		var foodLog = await _context.FoodLogs.FindAsync(id);
		return foodLog;
	}

	public async Task<FoodLog> CreateFoodLog(FoodLog foodLog)
	{
		_context.FoodLogs.Add(foodLog);
		await _context.SaveChangesAsync();
		return foodLog;
	}

	public async Task<FoodLog> UpdateFoodLog(int id, Shared.Domain.FoodLog foodLog)
	{
		var toUpdate = await _context.FoodLogs.FindAsync(id);
		if (toUpdate == null)
		{
			return null;
		}
		toUpdate.Date = foodLog.Date;
		toUpdate.UpdatedBy = foodLog.UpdatedBy;
		toUpdate.DateUpdated = foodLog.DateUpdated;
		toUpdate.DateCreated = foodLog.DateCreated;
		toUpdate.CreatedBy = foodLog.CreatedBy;

		await _context.SaveChangesAsync();

		return toUpdate;
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
}