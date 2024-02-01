using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Client.Services.FoodLogService
{
    public interface IFoodLogService
	{
		List<FoodLogging> FoodLogs { get; set; }

		Task GetFoodLogs(string userId);

		Task<FoodLogging?> GetFoodLogById(int id);

		Task<FoodLogging?> CreateFoodLog(FoodLogging foodLogDto);

		Task UpdateFoodLog(int id, FoodLogging foodLogDto);

		Task DeleteFoodLog(int id);
	}
}
