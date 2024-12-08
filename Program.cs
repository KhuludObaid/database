
using Microsoft.EntityFrameworkCore;
using TrainReservationAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Configure DbContext for SQLite
builder.Services.AddDbContext<TrainReservationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TrainReservationDB")));





// Register UserService for authentication


// Add controllers
builder.Services.AddControllers();

// Optional: Add OpenAPI/Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Enable authentication middleware
app.UseAuthorization();  // Enable authorization middleware

app.MapControllers(); // Enable controller endpoints

app.Run();
