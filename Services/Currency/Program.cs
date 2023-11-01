using Currency.CurrencyLogic.Contracts.Repositories;
using Currency.CurrencyLogic.Implementations.Repositories;
using Currency.DataAccess;
using Currency.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

var homedir = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}";
var externalConfigFileName = $"config/{builder.Environment.EnvironmentName}.json";

var externalConfigFilepath = Path.Combine(homedir, externalConfigFileName);

configuration
    .AddJsonFile(externalConfigFilepath, optional: false)
    .Build();


// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(fvc =>
{
    fvc.RegisterValidatorsFromAssemblyContaining<Program>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContextPool<AppDbContext>(options => {
    options.UseNpgsql(configuration.GetConnectionString("AppDb"));
});

builder.Services.AddTransient<ICurrencyRepository, CurrencyRepository>();

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CurrencyService", Version = "v1.7" });
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
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<TokenAuthenticationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
