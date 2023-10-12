using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ScsMarketplace.API.Persistence;
using ScsMarketplace.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


// var parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
var homedir = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}";  // The directory containing your configuration files
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var externalConfigFileName = $"config\\{environment}.json";

// Construct the file path using Path.Combine
var externalConfigFilepath = Path.Combine(homedir, externalConfigFileName);
// Load configuration here
var _configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: false)
    .AddJsonFile(externalConfigFilepath, optional: false)
    .Build();


var builder = WebApplication.CreateBuilder(args);
ILogger logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

// Change the port to 5000
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000);
});


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Register SwaggerGen
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ScsMarketplace.API", Version = "v1" });

    // Define the security scheme
    c.AddSecurityDefinition("X-Token", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Name = "X-Token",
        Description = "API Token",
    });

    // Use the security requirement
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "X-Token"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddScoped<IMessageProducer, MessageProducer>();
 
// Database
var connectionString = $"Host={_configuration["POSTGRES_HOST"]};"
    + $"Database={_configuration["POSTGRES_DATABASE"]};"
    + $"Port={_configuration["POSTGRES_PORT"]};"
    + $"Username={_configuration["POSTGRES_USERNAME"]};"
    + $"Password={_configuration["POSTGRES_PASSWORD"]};";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    builder.Logging.AddConsole(); // Add console logging
    builder.Logging.AddDebug();   // Add debug output logging
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScsMarketplace.API v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();


// string token1= "12465";//_configuration["CommonConfig:SCS_API_KEY"];
// app.UseMiddleware<TokenAuthenticationMiddleware>(token1); // Load token from configuration
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();
app.Run();
