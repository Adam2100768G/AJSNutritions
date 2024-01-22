using System.Data;

namespace AJSNutritions.Shared;

public class FoodLogDto
{
	public int Id { get; set; }

	public DateTime Date { get; set; } = new();

	public String UserName { get; set; } = String.Empty;
}