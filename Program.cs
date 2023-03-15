using zoo_mgmt.Models;
using zoo_mgmt;
using zoo_mgmt.Repositories;
using zoo_mgmt.Data;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using NLog;
using NLog.Config;
using NLog.Targets;

var builder = WebApplication.CreateBuilder(args);

var config = new LoggingConfiguration();
var target = new FileTarget { FileName = @"C:\Training\zoo_mgmt\ZooMgmt.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
config.AddTarget("File Logger", target);
config.LoggingRules.Add(new LoggingRule("*", NLog.LogLevel.Debug, target));
LogManager.Configuration = config;


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IAnimalsRepo, AnimalsRepo>();

builder.Services.AddDbContext<ZooManagementDbContext>(options =>
            {
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
                options.UseSqlite("Data Source=zoo_mgmt.db");
            });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "zoo", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "zoo v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

CreateDbIfNotExists(app);

app.Run();


// var host = CreateHostBuilder(args).Build();

// CreateDbIfNotExists(host);

// host.Run();


static void CreateDbIfNotExists(IHost host)
{
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ZooManagementDbContext>();
    context.Database.EnsureCreated();

    if (!context.Animals.Any())
    {
        var animals = SampleAnimals.GetAnimals();
        context.Animals.AddRange(animals);
        context.SaveChanges();
    }
}

