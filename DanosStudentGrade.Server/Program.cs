using DanosStudentGrade.Server.Data;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllers();

// Configure Entity Framework with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register application services
builder.Services.AddScoped<DanosStudentGrade.Server.Services.StudentGradeService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Serve static files for Angular frontend
app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

// Fallback to index.html for Angular routing
app.MapFallbackToFile("/index.html");

// Initialize database on startup (for development)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    db.Database.Migrate();
}

app.Run();
