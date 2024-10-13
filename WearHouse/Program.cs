using Microsoft.EntityFrameworkCore;
using WearHouse.Data;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); //swagger
builder.Services.AddSwaggerGen(); //swagger

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseDefaultFiles();

app.MapControllers();

app.UseStaticFiles();

app.UseRouting();


/*
app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthentication();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{action=Index}/{id?}");
*/

app.Run();
