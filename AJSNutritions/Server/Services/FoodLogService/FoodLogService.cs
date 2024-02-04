using AJSNutritions.Server.Data;
using AJSNutritions.Server.Models;
using AJSNutritions.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AJSNutritions.Server.Services.FoodLogService;

// Server side CRUD implementation for FoodLog
public class FoodLogService : IFoodLogService
{
	private readonly ApplicationDbContext _context;
	private readonly UserManager<ApplicationUser> _userManager;

	public FoodLogService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
	{
		_context = context;
		_userManager = userManager;
	}

	// FoodLogs have a foreign key to the user, so we need to get the user's food logs
	public async Task<List<FoodLog>> GetFoodLogs(int userId)
	{
		return await _context.FoodLogs
			.Where(fl => fl.UserId == userId)		// Get all the food logs for the user
			.Select(fl => new FoodLog					// create a DTO to return
			{
				Id = fl.Id,
				Description = fl.Description,
				Quantity = fl.Quantity,
				DishId = fl.DishId,
				Date = fl.Date,
				CreatedBy = fl.CreatedBy,
				DateCreated = fl.DateCreated,
				UpdatedBy = fl.UpdatedBy,
				DateUpdated = fl.DateUpdated
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

	public async Task<FoodLog?> UpdateFoodLog(int id, FoodLog foodLog)
	{
		var toUpdate = await _context.FoodLogs.FindAsync(id);
		if (toUpdate == null)
		{
			return null;
		}
		toUpdate.Date = foodLog.Date;
		toUpdate.Description = foodLog.Description;
		toUpdate.Quantity = foodLog.Quantity;
		toUpdate.DishId = foodLog.DishId;
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