using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestWork.Tasks.Application.Modules.Files.Commands;
using TestWork.Tasks.Application.Modules.Files.Queries;

namespace TestWork.Tasks.Api.Controllers;

/// <summary>
///     Контроллер для работы с файлами в файловом хранилище
/// </summary>
[ApiController]
[Route("file-storage")]
public class FileStorageController(ISender sender) : ControllerBase
{
    /// <summary>
    ///     Скачивание файла по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Файл</returns>
    [HttpGet("{id:guid}")]
    public async Task<FileStreamResult> DownloadAsync(Guid id, CancellationToken token)
    {
        var file = await sender.Send(new DownloadFileQuery(id), token);
        return File(file.OpenReadStream(), "application/octet-stream", file.FileName);
    }

    /// <summary>
    ///     Загрузка файла в файловое хранилище
    /// </summary>
    /// <param name="file">Файл</param>
    /// <param name="token">Токен отмены</param>
    /// <returns>Идентификатор файла</returns>
    [HttpPost]
    public async Task<Guid> UploadAsync(IFormFile file, CancellationToken token)
    {
        return await sender.Send(new UploadFileCommand(file), token);
    }
}