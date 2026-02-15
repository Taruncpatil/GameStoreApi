using Microsoft.EntityFrameworkCore;
using GameStoreApi.Data;
using GameStoreApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Register DbContext
builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameStore")));

// Register services
builder.Services.AddScoped<IGameService, GameService>();

var app = builder.Build();

// Global exception handler
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(new
        {
            Message = "An unexpected error occurred."
        });
    });
});

// Map controllers
app.MapControllers();

app.Run();
