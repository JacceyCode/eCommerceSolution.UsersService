using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure and Core services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controllers with JSON options to handle enum serialization as strings
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(ApplicationUserMappingProfile).Assembly);

// Build the web application
var app = builder.Build();

// Use global exception handling middleware
app.UseGlobalExceptionHandlingMiddleware();

// Routing 
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.UseDeveloperExceptionPage();
app.Run();
