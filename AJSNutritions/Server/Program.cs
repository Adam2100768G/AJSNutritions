using AJSNutritions.Server.Data;
using AJSNutritions.Server.Models;
using AJSNutritions.Server.Services.DishService;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
    {
	    const string OpenId = "openid";

		options.IdentityResources[OpenId].UserClaims.Add(JwtClaimTypes.Role);
	    options.ApiResources.Single().UserClaims.Add(JwtClaimTypes.Role);
	});

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove(JwtClaimTypes.Role);

builder.Services.AddAuthentication().AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IDishService, DishService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
	var context = services.GetRequiredService<ApplicationDbContext>();
	var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
	var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

	context.Database.Migrate();

	try
	{
		DataSeeder.SeedData(context, userManager, roleManager).Wait();
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred seeding the DB.");
	}
}
    
app.Run();
