using domain.interfaces;
using infrastructure.repositories;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FoodServiceContext>(options =>
    options.UseInMemoryDatabase("FoodServiceDB"));
// Add services to the container.
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<DbInitializer>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();
