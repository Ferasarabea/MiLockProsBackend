using MiLockProsBackend.Data;  // Ensure you're using your DbContext namespace
using MiLockProsBackend.Hubs;  // Import your custom SignalR hubs
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
// Add services to the container
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Ensure Swagger is added

// Configure Entity Framework and database connection
builder.Services.AddDbContext<LocksmithDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add SignalR for real-time messaging
builder.Services.AddSignalR();

var app = builder.Build();
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Enable Swagger generation
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiLockPros API v1"));
}

// Enable routing and authorization middleware
app.UseRouting();
app.UseAuthorization();

// Map controllers and hubs
app.MapControllers();
app.MapHub<NotificationHub>("/notificationHub");
app.MapHub<ChatHub>("/chatHub");

app.Run();


