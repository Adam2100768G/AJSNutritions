using AJSNutritions.Client;
using AJSNutritions.Client.Services.DishService;
using AJSNutritions.Client.Services.FoodLogService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("AJSNutritions.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AJSNutritions.ServerAPI"));
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<IFoodLogService, FoodLogService>();
builder.Services.AddApiAuthorization();



await builder.Build().RunAsync();
