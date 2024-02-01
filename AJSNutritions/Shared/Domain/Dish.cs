using System.ComponentModel.DataAnnotations;

namespace AJSNutritions.Shared.Domain;

public class Dish : BaseDomainModel
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;

    public int Calories { get; set; }
}