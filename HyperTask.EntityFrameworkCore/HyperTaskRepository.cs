using HyperTask.Domain.HyperTasks;

namespace HyperTask.EntityFrameworkCore;

//Ambiguous Referans hatasından dolayı Domain using bloğu eklendi.
public class HyperTaskRepository : RepositoryBase<Domain.HyperTasks.HyperTask, int>, IHyperTaskRepository
{
    public HyperTaskRepository(HyperTaskDbContext context) : base(context)
    {
    }
}

