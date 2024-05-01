using dotenv.net;

using IFTools.Components;
using IFTools.Data;

DotEnv.Load(new DotEnvOptions(true, new [] {"../.env"}));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<InfiniteFlightApiService>();
builder.Services.AddSingleton<AircraftGuidsService>();
builder.Services.AddScoped<CurrentPage>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

InfiniteFlightApiService.Init();
AircraftGuidsService.Init();

app.Run();