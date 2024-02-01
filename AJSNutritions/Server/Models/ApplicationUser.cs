using Microsoft.AspNetCore.Identity;

namespace AJSNutritions.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
		public int? UserId { get; set; }

		public int? StaffId { get; set; }
	}
}
