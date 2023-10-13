using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AuthenticationService.Persistence;
using AuthenticationService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;


// var parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
var homedir = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}";  // The directory containing your configuration files
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var externalConfigFileName = $"config\\{environment}.json";

// Construct the file path using Path.Combine
var externalConfigFilepath = Path.Combine(homedir, externalConfigFileName);
// Load configuration here
var configuration = new ConfigurationBuilder()
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


string expectedToken = configuration["SCS_API_KEY"]; // Make sure you define "ExpectedToken" in your configuration.
// if (string.IsNullOrEmpty(expectedToken) || token != expectedToken)
// {
//     return AuthenticateResult.Fail("Invalid token.");
// }

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IConfiguration>(configuration);
// Authorization and authentication
builder.Services.AddAuthentication("TokenAuth")
            .AddScheme<AuthenticationSchemeOptions, TokenAuthenticationHandler>("TokenAuth", options => { });

builder.Services.AddAuthorization();
// builder.Services.AddAuthorization(options =>
//     {
//         options.AddPolicy("TokenAuth", policy =>
//         {
//             policy.RequireAuthenticatedUser();
//             // policy.Requirements.Add(new TokenRequirement("12345"));
//         });
//     });


// Register SwaggerGen
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthenticationService", Version = "v1" });
    c.AddSecurityDefinition("X-Token", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Name = "X-Token",
        Description = "API Token",
    });

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

    // // Define the security scheme for SessionId
    // c.AddSecurityDefinition("SessionId", new OpenApiSecurityScheme
    // {
    //     Type = SecuritySchemeType.ApiKey,
    //     In = ParameterLocation.Header,
    //     Name = "SessionId",
    //     Description = "Session ID",
    // });

    // Define a custom parameter for SessionId
    // c.OperationFilter<AddSessionIdHeaderParameter>();
});


builder.Services.AddScoped<IMessageProducer, MessageProducer>();

// Database
var connectionString = $"Host={configuration["POSTGRES_HOST"]};"
    + $"Database={configuration["POSTGRES_DATABASE"]};"
    + $"Port={configuration["POSTGRES_PORT"]};"
    + $"Username={configuration["POSTGRES_USERNAME"]};"
    + $"Password={configuration["POSTGRES_PASSWORD"]};";
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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthenticationService v1");
    c.RoutePrefix = string.Empty;
});




// app.UseMiddleware<TokenAuthenticationMiddleware>("token");
app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();


app.MapControllers();
app.Run();
