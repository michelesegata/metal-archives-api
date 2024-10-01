using MetalArchivesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetalArchivesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetalArchivesApiController : ControllerBase
{
    private readonly IMetalArchivesService _metalArchivesService;

    public MetalArchivesApiController(IMetalArchivesService metalArchivesService)
    {
        _metalArchivesService = metalArchivesService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchBandsByName([FromQuery] string bandName)
    {
        if (string.IsNullOrEmpty(bandName))
        {
            return BadRequest("Band name is required.");
        }

        var result = await _metalArchivesService.SearchBandsByName(bandName);
        return Ok(result);
    }

}