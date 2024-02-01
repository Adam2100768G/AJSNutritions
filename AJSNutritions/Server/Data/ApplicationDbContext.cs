using AJSNutritions.Server.Models;
using AJSNutritions.Shared;
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
        // add a table for the Dishes in the database
        public DbSet<Dish> Dishes { get; set; } = null!;
        // add a table for the food log in the database
        public DbSet<FoodLog> FoodLogs { get; set; } = null!;
        // add a table for the food logged item in the database
        public DbSet<FoodLoggedItem> FoodLoggedItems { get; set; } = null!;


    }
}
