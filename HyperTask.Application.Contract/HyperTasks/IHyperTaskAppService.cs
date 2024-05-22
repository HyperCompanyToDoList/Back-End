using HyperTask.Application.Contract.HyperTasks.Dtos;

namespace HyperTask.Application.Contract.HyperTasks
{
    public interface IHyperTaskAppService
    {
        Task<HyperTaskDto> AddTask(HyperTaskDto task);
        Task<HyperTaskDto> Update(HyperTaskDto task);
        Task RemoveTask(HyperTaskDto task);
        Task RemoveTask(int id);
        Task<List<HyperTaskDto>> GetAllTasks();
        Task<List<HyperTaskDto>> GetUnCompletedTasks();
        Task<List<HyperTaskDto>> GetCompletedTasks();
        Task SignAsCompleted(int id);
    }
}
