using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductHandler.Data;
using ProductHandler.Services;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductHandlerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductHandlerContext") ?? throw new InvalidOperationException("Connection string 'ProductHandlerContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<DbSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseItToSeedSqlServer();  //custom extension method to seed the DB
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
