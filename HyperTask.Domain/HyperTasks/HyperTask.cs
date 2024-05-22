using Emr.Common;

namespace HyperTask.Domain.HyperTasks;


public class HyperTask : IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public bool IsCompleted { get; set; }
}



