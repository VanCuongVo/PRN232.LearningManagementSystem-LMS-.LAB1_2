using Microsoft.AspNetCore.Mvc.ApiExplorer;
using PRN232.LMS.API.Configurations;
using PRN232.LMS.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Content Negotation
builder.Services.AddMvcConfiguration();
builder.Services.AddControllers();
// API versioning
builder.Services.AddApiVersion();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

// Database
builder.Services.AddDatabase(builder.Configuration);
// Service
builder.Services.AddDependencyInjection();
// Validator
builder.Services.AddFluentValidationConfig();
builder.Services.AddValidationConfiguration();
builder.Services.AddCustomJsonOptions();

builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();


var app = builder.Build();
app.UseSwaggerConfiguration();
await app.InitialiseDatabaseAsync();
app.UseAuthentication();
app.UseAuthorization();
app.UseGlobalException();
app.UseRequestLogging();
app.MapControllers();
app.Run();