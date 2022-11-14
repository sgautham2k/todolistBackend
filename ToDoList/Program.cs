using ToDoList.Controllers;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using ToDoList.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ToDoListDbContext>(x => x.UseSqlServer
(builder.Configuration.GetConnectionString("todolistconn")));
builder.Services.AddCors(c => c.AddPolicy("todolist", c => c.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthenticate, Authenticateimpl>();
builder.Services.AddScoped<INotes, NotesImpl>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
