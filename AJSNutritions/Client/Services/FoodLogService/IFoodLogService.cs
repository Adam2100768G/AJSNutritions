using AJSNutritions.Shared;

namespace AJSNutritions.Client.Services.FoodLogService
{
	public interface IFoodLogService
	{
		List<FoodLogDto> FoodLogs { get; set; }

		Task GetFoodLogs(string userId);

		Task<FoodLogDto?> GetFoodLogById(int id);

		Task<FoodLogDto?> CreateFoodLog(FoodLogDto foodLogDto);

		Task UpdateFoodLog(int id, FoodLogDto foodLogDto);

		Task DeleteFoodLog(int id);
	}
}
