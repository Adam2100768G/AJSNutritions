using AJSNutritions.Shared.Domain;

namespace AJSNutritions.Server.Models;

public class FoodLoggedItem
{
	public int Id { get; set; }

	public int DishQuantity { get; set; }

	// Required foreign key to the food log that owns this item
	public int FoodLogId { get; set; }
	
	// reference to the food log that owns this item
	public FoodLog FoodLog { get; set; } = null!;

	//TODO: Add a required foreign key to the dish that this item is for
}