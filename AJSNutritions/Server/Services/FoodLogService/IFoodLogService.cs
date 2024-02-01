using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Server.Services.FoodLogService;

public interface IFoodLogService
{
	Task<List<FoodLogging>> GetFoodLogs(string userName);

	Task<FoodLogging?> GetFoodLogById(int id);

	Task<FoodLogging> CreateFoodLog(FoodLogging foodLogging);

	Task<FoodLogging> UpdateFoodLog(int id, FoodLogging foodLogging);

	Task<bool> DeleteFoodLog(int id);
}