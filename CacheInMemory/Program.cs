using CacheInMemory.Cache;
using CacheInMemory.Model;
using CacheInMemory.Repositories;
using CacheInMemory.Services;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IDataContext, DatabaseContext>();
builder.Services.AddScoped<ICacheContext, CacheContext>();
builder.Services.AddScoped<IBranchesRespository, BranchesRespository>();


builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IBranchesService, BranchesService>();
builder.Services.AddScoped<ICarsService, CarsService>();
builder.Services.AddScoped<IRegisteredCarsService, RegisteredCarsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => {
    options.ExampleFilters();
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();


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

public partial class Program { }