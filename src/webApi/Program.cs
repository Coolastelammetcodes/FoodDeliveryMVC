using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using infrastructure.data;
using domain.interfaces;
using infrastructure.repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<RestaurantService>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddDbContext<FoodServiceContext>(options => options.UseInMemoryDatabase("TestDb"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<FoodServiceContext>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
