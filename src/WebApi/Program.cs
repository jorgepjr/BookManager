using Adapters;
using Adapters.Persistence;
using Application.Interfaces;
using Application.UseCases;
using Application.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookManagerContext>(options =>
           options.UseInMemoryDatabase("memo"));

builder.Services.AddScoped<IBookModule, BookModule>();
builder.Services.AddScoped<IBookPersistence, BookPersistence>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
