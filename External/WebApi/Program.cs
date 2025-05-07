using Application.Services;
using Domain.Interfaces;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

builder.Services.AddScoped<TaskService>();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var connectionString = builder.Configuration.GetConnectionString("Sqlite");
builder.Services.AddDbContext<EFDbContext>(opt => opt.UseSqlite(connectionString));

var app = builder.Build();
CreateDatabase(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapTasksEndpoints();
app.UseHttpsRedirection();
app.Run();


static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<EFDbContext>();
    dataContext?.Database.EnsureCreated();
}
