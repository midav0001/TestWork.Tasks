using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestWork.Tasks.Dal.Context;
using TestWork.Tasks.Dal.Repositories;
using TestWork.Tasks.Domain.Repositories;

namespace TestWork.Tasks.Dal.Infrastructure.Extensions;

/// <summary>
///     Методы регистрации сервисов для работы с бд
/// </summary>
public static class DataAccessServiceExtension
{
    /// <summary>
    ///     Регистрирует сервисы для работы с БД
    /// </summary>
    /// <param name="services">
    ///     Экземпляр класса <see cref="IServiceCollection" />
    /// </param>
    public static IServiceCollection ConfigurePostgresDataAccessServices(this IServiceCollection services)
    {
        return services.AddScoped<IDbContextFactory<TaskContext>, TaskContextFactory>()
            .AddScoped<ITaskRepository, TaskRepository>();
    }
}