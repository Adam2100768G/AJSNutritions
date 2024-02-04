using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Client.Services.DishService;

public interface IDishService
{
	List<Dish> Dishes { get; set; }

	Task GetDishes();

	Task<Dish?> GetDishById(int id);

	Task CreateDish(Dish dish);

	Task UpdateDish(int id, Dish dish);

	Task DeleteDish(int id);
}