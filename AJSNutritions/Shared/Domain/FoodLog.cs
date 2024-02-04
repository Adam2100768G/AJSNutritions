using System.Data;

namespace AJSNutritions.Shared.Domain;

/*
 FoodLog is a domain model for a food log entry.
 It has a date, description, quantity, and a FK to a dish and a FK to the user.
 */
public class FoodLog : BaseDomainModel
{
    public DateTime Date { get; set; } = new();

    public string? Description { get; set; } = string.Empty;

    public int? Quantity { get; set; } = 0;

    public int? DishId { get; set; }

    public int UserId { get; set; }
}