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

// Add API explorer services
builder.Services.AddEndpointsApiExplorer();
// Add Swagger generation services
builder.Services.AddSwaggerGen();

// Add CORS policy to allow cross-origin requests from any origin, method, and header
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(builder.Configuration["AllowedOrigns"] ?? "http://localhost:4200")
               .WithMethods("GET", "POST", "PUT", "DELETE")
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

// Build the web application
var app = builder.Build();

// Use global exception handling middleware
app.UseGlobalExceptionHandlingMiddleware();

// Routing 
app.UseRouting();

// Add swagger middleware to serve generated Swagger as a JSON endpoint and the Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

// Add CORS middleware to allow cross-origin requests from any origin, method, and header
app.UseCors();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllers();

app.UseDeveloperExceptionPage();
app.Run();
