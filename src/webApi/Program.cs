using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using infrastructure.data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FoodServiceContext>(options => options.UseInMemoryDatabase("TestDb"));
// Add services to the container.
builder.Services.AddIdentity<IdentityUser, IdentityRole>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.Run();
