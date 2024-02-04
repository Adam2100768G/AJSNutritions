using AJSNutritions.Client;
using AJSNutritions.Client.Services;
using AJSNutritions.Client.Services.DishService;
using AJSNutritions.Client.Services.FoodLogService;
using AJSNutritions.Client.Services.StaffService;
using AJSNutritions.Client.Services.UserService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("AJSNutritions.ServerAPI", (sp, 
client) => {
    client.BaseAddress = new
Uri(builder.HostEnvironment.BaseAddress);
    client.EnableIntercept(sp);
        })
.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AJSNutritions.ServerAPI"));
// Add our services scoped to the current user
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IFoodLogService, FoodLogService>();
builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<HttpInterceptorService>();
builder.Services.AddApiAuthorization();



await builder.Build().RunAsync();
