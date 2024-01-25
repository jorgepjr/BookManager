using Adapters;
using Adapters.Persistence;
using Application.Interfaces;
using Application.UseCases.Interfaces;
using Application.UseCases.Modules;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookManagerContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("BookManager")));

builder.Services.AddScoped<IBookPersistence, BookPersistence>();
builder.Services.AddScoped<IInventoryPersistence, InventoryPersistence>();
builder.Services.AddScoped<IClientPersistence, ClientPersistence>();

builder.Services.AddScoped<IBookModule, BookModule>();
builder.Services.AddScoped<IClientModule, ClientModule>();

var serviceProvider = builder.Services.BuildServiceProvider();
using (var serviceScope = serviceProvider.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<BookManagerContext>();
   await context.Database.MigrateAsync();
}

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

await app.RunAsync();
