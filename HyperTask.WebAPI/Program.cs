

using AutoMapper;
using HyperTask.Application;
using HyperTask.Application.Contract.HyperTasks;
using HyperTask.Application.HyperTasks;
using HyperTask.Application.HyperTasks.MapProfiles;
using HyperTask.Domain.HyperTasks;
using HyperTask.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

//builder.Services.AddAutoMapper(c => c.AddProfiles(GetProfiles()));
builder.Services.AddScoped<IHyperTaskRepository, HyperTaskRepository>();
builder.Services.AddScoped<IHyperTaskAppService, HyperTaskAppService>();



IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddEntityFrameworkSqlServer();
var connString = configuration.GetConnectionString("BaseDb");
builder.Services.AddDbContext<HyperTaskDbContext>(i => i.UseSqlServer(connString));

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


List<Profile> GetProfiles()
{
    return new List<Profile>()
        {
            new HyperTaskMapProfile()
        };
}