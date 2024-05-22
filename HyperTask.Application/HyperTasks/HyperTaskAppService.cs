using AutoMapper;
using HyperTask.Application.Contract.HyperTasks;
using HyperTask.Application.Contract.HyperTasks.Dtos;
using HyperTask.Domain.HyperTasks;

namespace HyperTask.Application.HyperTasks;

public class HyperTaskAppService : IHyperTaskAppService
{
    private readonly IHyperTaskRepository _hyperTaskRepository;
    private readonly IMapper _mapper;

    public HyperTaskAppService(IMapper mapper, IHyperTaskRepository hyperTaskRepository)
    {
        _mapper = mapper;
        _hyperTaskRepository = hyperTaskRepository;
    }

    public async Task<HyperTaskDto> AddTask(HyperTaskDto task)
    {

        var entity = _mapper.Map<Domain.HyperTasks.HyperTask>(task);
        return _mapper.Map<HyperTaskDto>(await _hyperTaskRepository.AddAsync(entity, true));
    }

    public async Task<List<HyperTaskDto>> GetAllTasks()
    {
        var query = await _hyperTaskRepository.GetAll();

        return query.Select(i => _mapper.Map<HyperTaskDto>(i)).ToList();
    }

    public async Task<List<HyperTaskDto>> GetUnCompletedTasks()
    {
        var query = await _hyperTaskRepository.GetAll();
        query = query.Where(i => i.IsCompleted == false);

        return query.Select(i => _mapper.Map<HyperTaskDto>(i)).ToList();
    }

    public async Task<List<HyperTaskDto>> GetCompletedTasks()
    {
        var query = await _hyperTaskRepository.GetAll();
        query = query.Where(i => i.IsCompleted == true);

        return query.Select(i => _mapper.Map<HyperTaskDto>(i)).ToList();
    }

    public async Task RemoveTask(HyperTaskDto task)
    {
        var entity = _mapper.Map<Domain.HyperTasks.HyperTask>(task);
        await _hyperTaskRepository.Remove(entity, true);

    }

    public async Task RemoveTask(int id)
    {
        var entity = await _hyperTaskRepository.GetAsync(id);
        await _hyperTaskRepository.Remove(entity, true);

    }
    public async Task<HyperTaskDto> Update(HyperTaskDto task)
    {
        var entity = _mapper.Map<Domain.HyperTasks.HyperTask>(task);
        
        return _mapper.Map<HyperTaskDto>(await _hyperTaskRepository.UpdateAsync(entity, true));

    }

    public async Task SignAsCompleted(int id)
    {
        var entity = await _hyperTaskRepository.GetAsync(id);
        entity.IsCompleted = true;
        await _hyperTaskRepository.UpdateAsync(entity,true);
        
    }
}
