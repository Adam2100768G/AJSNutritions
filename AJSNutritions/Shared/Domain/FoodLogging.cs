using System.Data;

namespace AJSNutritions.Shared.Domain;

public class FoodLogging : BaseDomainModel
{
    public DateTime Date { get; set; } = new();

    public int UserId { get; set; }
}