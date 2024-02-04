using System.ComponentModel.DataAnnotations;

namespace AJSNutritions.Shared.Domain;

/*
 Dish is a domain model for a food item.
 It has a name, description, and calorie count.
 */
public class Dish : BaseDomainModel
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;

    public int Calories { get; set; }

    public int? DishType { get; set; }
}