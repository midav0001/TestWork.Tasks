using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestWork.Tasks.Application.Modules.Files.Commands;
using TestWork.Tasks.Application.Modules.Files.Queries;

namespace TestWork.Tasks.Api.Controllers;

[ApiController]
[Route("files")]
public class FilesController(ISender sender) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<FileStreamResult> Download(Guid id, CancellationToken token)
    {
        var file = await sender.Send(new DownloadFileQuery(id), token);
        return File(file.OpenReadStream(), "application/octet-stream", file.FileName);
    }

    [HttpPost]
    public async Task<Guid> Download(IFormFile file, CancellationToken token)
    {
        return await sender.Send(new UploadFileCommand(file), token);
    }
}