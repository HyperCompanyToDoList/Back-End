using Microsoft.EntityFrameworkCore;

namespace HyperTask.EntityFrameworkCore
{
    public class HyperTaskDbContext : DbContext
    {
        public HyperTaskDbContext(DbContextOptions<HyperTaskDbContext> options) : base(options)
        {

        }
        public DbSet<Domain.HyperTasks.HyperTask> Tasks { get; set; }






    }
}
