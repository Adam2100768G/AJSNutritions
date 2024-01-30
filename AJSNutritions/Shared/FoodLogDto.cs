using System.Data;

namespace AJSNutritions.Shared;

public class FoodLogDto
{
    public int Id { get; set; }

    public DateTime Date { get; set; } = new();

    public string UserName { get; set; } = string.Empty;
}