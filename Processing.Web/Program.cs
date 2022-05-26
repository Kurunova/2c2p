using Processing.Core.Startup;
using Processing.DataLayer.Startup;
using Processing.Web.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json");

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
	options.Filters.Add(typeof(ExceptionFilter));
	options.Filters.Add(typeof(ValidateModelStateFilter));
});

builder.Services.AddDataLayer(builder.Configuration);
builder.Services.AddCore();

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();