using Microsoft.AspNetCore.Mvc;

namespace TestWork.Tasks.Api.Controllers;

[ApiController]
[Route("files")]
public class FilesController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IFormFile> Download(Guid id, CancellationToken token)
    {
        return null;
    }
}