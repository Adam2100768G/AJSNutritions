using System.Data;

namespace AJSNutritions.Shared;

public class FoodLog
{
	public int Id { get; set; }

	public DateTime Date { get; set; } = new();
}