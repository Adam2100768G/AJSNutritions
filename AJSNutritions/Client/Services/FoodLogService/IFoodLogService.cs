using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Client.Services.FoodLogService
{
    public interface IFoodLogService
	{
		List<FoodLog> FoodLogs { get; set; }

		Task GetFoodLogs(string userName);

		Task<FoodLog?> GetFoodLogById(int id);

		Task<FoodLog?> CreateFoodLog(FoodLog foodLog);

		Task UpdateFoodLog(int id, FoodLog foodLog);

		Task DeleteFoodLog(int id);
	}
}
