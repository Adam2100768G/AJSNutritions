using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Server.Services.FoodLogService;

public interface IFoodLogService
{
	Task<List<FoodLog>> GetFoodLogs(int userId);

	Task<FoodLog?> GetFoodLogById(int id);

	Task<FoodLog> CreateFoodLog(FoodLog foodLog);

	Task<FoodLog> UpdateFoodLog(int id, FoodLog foodLog);

	Task<bool> DeleteFoodLog(int id);
}