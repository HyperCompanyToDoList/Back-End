using AutoMapper;
using HyperTask.Application.Contract.HyperTasks.Dtos;

namespace HyperTask.Application.HyperTasks.MapProfiles
{
    public class HyperTaskMapProfile: Profile
    {
        public HyperTaskMapProfile()
        {
            CreateMap<HyperTaskDto, Domain.HyperTasks.HyperTask>().ReverseMap();
        }
    }
}
