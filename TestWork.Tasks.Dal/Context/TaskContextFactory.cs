using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestWork.Tasks.Dal.Infrastructure;


namespace TestWork.Tasks.Dal.Context;

public class TaskContextFactory : IDbContextFactory<TaskContext>
{
    public TaskContext CreateDbContext()
    {
        var configurationBuilder = new ConfigurationBuilder();

        var configurationRoot = configurationBuilder
            .AddJsonFile("appsettings.json")
            .AddUserSecrets("3fd8289e-2dc8-436e-a522-6aaf1ae5493d")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TaskContext>();

        var connectionString = configurationRoot.GetConnectionString(DataBaseKeys.ConnectionStringName);
        optionsBuilder.UseSqlServer(connectionString);

        return new TaskContext(optionsBuilder.Options);
    }
}