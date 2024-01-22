namespace AJSNutritions.Server.Models;

public class FoodLog
{
	public int Id { get; set; }

	public DateTime Date { get; set; }

	// Creates the one-many relationship between FoodLogDto and FoodLoggedItem.
	// The FoodLogDto is the one side of the relationship, and the FoodLoggedItem is the many side.
	// There may be 0 or more items in the collection.
	public ICollection<FoodLoggedItem> FoodLoggedItems { get; set; } = new List<FoodLoggedItem>();

	// Required foreign key to the user who owns this food log
	public string ApplicationUserId { get; set; }
	// reference to the user who owns this food log
	public ApplicationUser ApplicationUser { get; set;}	
}