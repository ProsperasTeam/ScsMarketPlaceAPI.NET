using Business.BusinessLogic.Contracts.Repositories;
using Business.BusinessLogic.Implementations.Repositories;
using Business.DataAccess;
using Business.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
var env=builder.Environment.EnvironmentName;
var homedir = $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}";  
var confDir="config";
var externalConfigFileName = $"{env}.json";
var externalConfigDir=Path.Combine(homedir,confDir);
var externalConfigFilepath = Path.Combine(externalConfigDir, externalConfigFileName);


configuration
    .AddJsonFile(externalConfigFilepath, optional: false)
    .Build();

// Add services to the container.



builder.Services.AddControllers().AddFluentValidation( fvc =>
{
    fvc.RegisterValidatorsFromAssemblyContaining<Program>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<AppDbContext>(options => {
    options.UseNpgsql(configuration.GetConnectionString("AppDb"));
});

builder.Services.AddTransient<IBusinessRepository, BusinessRepository>();

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BusinessService", Version = "v1.7" });
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


if (env!="Development"){
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(int.Parse(configuration["service_port"]));
    });
}


var app = builder.Build();

// Add your custom error handling middleware here.
app.UseSwagger();
app.UseSwaggerUI();


app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<TokenAuthenticationMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
