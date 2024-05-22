using AutoMapper;
using HyperTask.Application.Contract.HyperTasks;
using HyperTask.Application.HyperTasks;
using HyperTask.Application.HyperTasks.MapProfiles;
using HyperTask.Domain.HyperTasks;
using HyperTask.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HyperTask.Application;

public static class DependencyInjectionContainer
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(c => c.AddProfiles(GetProfiles()));
        services.AddScoped<IHyperTaskAppService, HyperTaskAppService>();
        services.AddScoped<IHyperTaskRepository, HyperTaskRepository>();
        services.AddScoped<IMapper, Mapper>();
    }


    static List<Profile> GetProfiles()
    {
        return new List<Profile>()
        {
            new HyperTaskMapProfile()
        };
    }
}
