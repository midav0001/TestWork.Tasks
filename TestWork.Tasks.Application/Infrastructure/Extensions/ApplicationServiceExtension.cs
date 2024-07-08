using Microsoft.Extensions.DependencyInjection;
using TestWork.Tasks.Application.Modules.FileStorages.Services;

namespace TestWork.Tasks.Application.Infrastructure.Extensions;

/// <summary>
///     Методы регистрации сервисов для уровня приложения
/// </summary>
public static class ApplicationServiceExtension
{
    /// <summary>
    ///     Регистрирует сервисы для уровня приложения
    /// </summary>
    /// <param name="services">Экземпляр класса <see cref="IServiceCollection" /></param>
    /// <returns>Ссылка на этот экземпляр после завершения операции</returns>
    public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
    {
        return services.AddScoped<IFileStorageService, FileStorageService>();
    }
}