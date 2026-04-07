using domain.interfaces;
using infrastructure.repositories;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<FoodServiceContext>(options =>
    options.UseSqlite(connectionString));
// Add services to the container.
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<IDishService, DishService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<ICourierRepository, CourierRepository>();
builder.Services.AddScoped<ICourierService, CourierService>();

builder.Services.AddScoped<DbInitializer>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers().AddJsonOptions(options => 
                    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter())
                );
builder.Services.AddSwaggerGen(s => {
                    s.ExampleFilters(); 
                    s.UseInlineDefinitionsForEnums();
                });

builder.Services.AddSwaggerExamplesFromAssemblyOf<RestaurantRequestPlaceholder>();
builder.Services.AddSwaggerExamplesFromAssemblyOf<CourierRequestPlaceholder>();
var app = builder.Build();

using (var scope = app.Services.CreateAsyncScope())
{
     var db = scope.ServiceProvider.GetRequiredService<FoodServiceContext>();
    await db.Database.MigrateAsync();

    var dbInit = scope.ServiceProvider.GetRequiredService<DbInitializer>();
    await dbInit.InitializeAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
