using Adapters.DBContexts;
using Adapters.Repositories;
using Adapters.Services;
using Application.Properties;
using Domain.Entities;
using Domain.Intefaces;
using Mongo2Go;
using MongoDB.Driver;
using System;

var builder = WebApplication.CreateBuilder(args);

// Get the current environment
var environment = builder.Environment.EnvironmentName;
// MongoDB Configuration
if (environment == "Testing")
{
    // Set up Mongo2Go for testing
    var runner = MongoDbRunner.Start();
    var connectionString = runner.ConnectionString;

    // Register MongoDB context with in-memory database
    builder.Services.AddSingleton<IDbContext>(sp =>
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("TestDatabase");
        return new MongoDbContext(database); // MongoDbContext es tu implementación
    });
}
else
{
    // Normal configuration for real environments
    var connectionString = builder.Configuration["MongoDb:ConnectionString"];
    var databaseName = builder.Configuration["MongoDb:DatabaseName"];

    //builder.Services.AddSingleton<IDbContext>(sp =>
    //{
    //    var client = new MongoClient(connectionString);
    //    var database = client.GetDatabase(databaseName);
    //    return new MongoDbContext(database); // MongoDbContext is your implementation
    //});
    builder.Services.AddSingleton<IMongoClient>(sp =>
    {
        return new MongoClient(connectionString);
    });

    builder.Services.AddSingleton(sp =>
    {
        var client = sp.GetRequiredService<IMongoClient>();
        var database = client.GetDatabase(databaseName);
        return database.GetCollection<Property>("properties");
    });
}

// Add services to the container.
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Request pipeline configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();