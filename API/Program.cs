using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Registrar DataContext con SQLite
builder.Services.AddDbContext<DataContext>(opt =>
{
    // Obtener la cadena de conexión desde appsettings.json
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.MapControllers();

app.Run();
