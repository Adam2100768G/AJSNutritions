namespace AJSNutritions.Shared;

public class Profile
{
	// The users profile
	public string User { get; set; }

	public DateOnly DateOfBirth { get; set; }

	public string Address { get; set; }

	public double Weight { get; set; }

	public int Height { get; set; }

	public int Gender { get; set; }
}