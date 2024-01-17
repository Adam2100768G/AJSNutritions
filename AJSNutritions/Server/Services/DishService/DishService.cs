using AJSNutritions.Server.Data;
using AJSNutritions.Shared;
using Microsoft.EntityFrameworkCore;

namespace AJSNutritions.Server.Services.DishService;

public class DishService: IDishService
{
	private readonly ApplicationDbContext _context;

	public DishService(ApplicationDbContext context)
	{
		_context = context;
	}
	public List<Dish> Dishes { get; set; } = new List<Dish>();

	public async Task<List<Dish>> GetDishes()
	{
		return await _context.Dishes.ToListAsync();
	}

	public async Task<Dish?> GetDishById(int id)
	{
		var dish = await _context.Dishes.FindAsync(id);
		return dish;
	}

	public async Task<Dish> CreateDish(Dish dish)
	{
		_context.Dishes.Add(dish);
		await _context.SaveChangesAsync();
		return dish;
	}

	public async Task<Dish> UpdateDish(int id, Dish dish)
	{
		var toUpdate = await _context.Dishes.FindAsync(id);
		if (toUpdate == null)
		{
			return null;
		}
		toUpdate.Name = dish.Name;
		toUpdate.Description = dish.Description;
		toUpdate.Calories = dish.Calories;

		await _context.SaveChangesAsync();

		return dish;
	}

	public async Task<bool> DeleteDish(int id)
	{
		var dish = await _context.Dishes.FindAsync(id);
		if (dish == null)
		{
			return false;
		}

		_context.Dishes.Remove(dish);
		await _context.SaveChangesAsync();

		return true;
	}
}