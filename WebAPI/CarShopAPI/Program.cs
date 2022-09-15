using CarShopAPI.Models;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<CarShopAPIDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CarShopAPIDbContext") ?? throw new InvalidOperationException("Connection string 'CarShopAPIDbContext' not found.")));

        // Add services to the container.
        builder.Services.AddScoped<IShopService, ShopService>();
        builder.Services.AddScoped<ICarService, CarService>();




        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}