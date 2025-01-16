using Application.Properties.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration["MongoDb:ConnectionString"];
var databaseName = builder.Configuration["MongoDb:DatabaseName"];

var dbContext = new DataAccess.DBContexts.DbContext(connectionString, databaseName);

builder.Services.AddSingleton(dbContext.GetDatabase());
builder.Services.AddScoped<Domain.Intefaces.IPropertyRepository, DataAccess.Repositories.PropertyRepository>();
builder.Services.AddScoped<GetPropertiesUseCase>();
builder.Services.AddScoped<CreatePropertyUseCase>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline de solicitudes
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();