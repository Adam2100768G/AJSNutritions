
namespace AJSNutritions.Shared.Domain
{
	public class Staff : BaseDomainModel
	{
		public string Name { get; set; }

		public string Email { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Password { get; set; }

		public int? Gender { get; set; }

		public string Address { get; set; }

		public int? Phone { get; set; }

		public string StaffType { get; set; }

	}
}
