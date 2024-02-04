using AJSNutritions.Server.Models;
using AJSNutritions.Shared.Domain;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AJSNutritions.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

            // Ensure the columns are nullable
			modelBuilder.Entity<Staff>().Property(s => s.Email).IsRequired(false);
			modelBuilder.Entity<Staff>().Property(s => s.Address).IsRequired(false);
			modelBuilder.Entity<Staff>().Property(s => s.StaffType).IsRequired(false);
		}

        // add a table for the Dishes in the database
        public DbSet<Dish> Dishes { get; set; } = null!;
        // add a table for the food log in the database
        public DbSet<FoodLog> FoodLogs { get; set; } = null!;
        // add a table for the User in the database
        public DbSet<User> Users { get; set; } = null!;
        // add a table for the staff in the database
        public DbSet<Staff> Staffs {  get; set; } = null!;

    }
}
