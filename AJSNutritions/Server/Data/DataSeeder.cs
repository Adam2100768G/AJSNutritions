using AJSNutritions.Server.Models;
using AJSNutritions.Shared;
using Microsoft.AspNetCore.Identity;

namespace AJSNutritions.Server.Data
{
	// Not needed, we are not using roles
	public class DataSeeder
	{
		public static async Task SeedData(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			await context.Database.EnsureCreatedAsync();

			const string pw = "P@ssw0rd!";

			// Seed the roles if missing
			await AddRoleIfMissing(roleManager, Constants.Roles.Admin);
			await AddRoleIfMissing(roleManager, Constants.Roles.Staff);
			await AddRoleIfMissing(roleManager, Constants.Roles.User);
			// seed test users if missing
			await AddUserIfMissing(userManager, "admin", "admin@test.com", pw, Constants.Roles.Admin);
			await AddUserIfMissing(userManager, "staff", "staff@test.com", pw, Constants.Roles.Staff);
			await AddUserIfMissing(userManager, "user", "user@test.com", pw, Constants.Roles.User);
		}

		private static async Task AddRoleIfMissing(RoleManager<IdentityRole> roleManager, string role)
		{
			if (await roleManager.FindByNameAsync(role) == null)
			{
				await roleManager.CreateAsync(new IdentityRole(role));
			}
		}

		private static async Task AddUserIfMissing(UserManager<ApplicationUser> userManager, string userName, string email, string pw, string role)
		{
			if (await userManager.FindByEmailAsync(email) == null)
			{
				var user = new ApplicationUser
				{
					UserName = email,
					Email = email,
					EmailConfirmed = true
				};

				var result = await userManager.CreateAsync(user, pw);

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, role);
				}
			}
		}
	}
}
