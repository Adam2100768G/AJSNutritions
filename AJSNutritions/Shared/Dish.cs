using System.ComponentModel.DataAnnotations;

namespace AJSNutritions.Shared;

public class Dish
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;

    public int Calories { get; set; }
}