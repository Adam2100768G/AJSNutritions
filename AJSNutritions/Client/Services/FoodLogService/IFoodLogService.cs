using AJSNutritions.Shared;

namespace AJSNutritions.Client.Services.FoodLogService
{
	public interface IFoodLogService
	{
		List<FoodLog> FoodLogs { get; set; }

		Task GetFoodLogs();

		Task<FoodLog?> GetFoodLogById(int id);

		Task CreateFoodLog(FoodLog foodLog);

		Task UpdateFoodLog(int id, FoodLog foodLog);

		Task DeleteFoodLog(int id);
	}
}
