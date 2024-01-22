using AJSNutritions.Shared;

namespace AJSNutritions.Server.Services.FoodLogService;

public interface IFoodLogService
{
	Task<List<FoodLogDto>> GetFoodLogs(string userName);

	Task<FoodLogDto?> GetFoodLogById(int id);

	Task<FoodLogDto> CreateFoodLog(FoodLogDto foodLogDto);

	Task<FoodLogDto> UpdateFoodLog(int id, FoodLogDto foodLogDto);

	Task<bool> DeleteFoodLog(int id);
}