using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Server.Services.DishService;

// Server side CRUD interface for Dish
public interface IDishService
{
	List<Dish> Dishes { get; set; }

	Task<List<Dish>> GetDishes();

	Task<Dish?> GetDishById(int id);

	Task<Dish> CreateDish(Dish dish);

	Task<Dish?> UpdateDish(int id, Dish dish);

	Task<bool> DeleteDish(int id);
}