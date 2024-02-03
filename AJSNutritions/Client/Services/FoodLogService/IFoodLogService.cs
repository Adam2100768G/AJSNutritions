using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Client.Services.FoodLogService
{
    public interface IFoodLogService
	{
		Task<List<FoodLog>> GetFoodLogs(int userId);

		Task<FoodLog?> GetFoodLogById(int id);

		Task<FoodLog?> CreateFoodLog(FoodLog foodLog);

		Task<FoodLog?> UpdateFoodLog(int id, FoodLog foodLog);

		Task DeleteFoodLog(int id);
	}
}
