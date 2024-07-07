using Microsoft.EntityFrameworkCore;

namespace TestWork.Tasks.Dal.Context;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }
}