using AutoMapper;
using MetalArchivesApi.Dto;
using MetalArchivesApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace MetalArchivesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetalArchivesApiController(
    IMetalArchivesService metalArchivesService,
    UserManager<IdentityUser> userManager,
    IJwtService jwtService,
    IMapper mapper,
    ILogger logger)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var user = await userManager.FindByNameAsync(model.Username);
        if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
        {
            logger.Error("Invalid username or password.");
            return Unauthorized();
        }
        logger.Information("User {Username} logged in.", model.Username);
        var token = jwtService.GenerateJwtToken(user.Id);
        return Ok(new { token });
    }

    [HttpGet("search")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> SearchBandsByName([FromQuery] string bandName)
    {
        if (string.IsNullOrEmpty(bandName))
        {
            logger.Error("Band name is required.");
            return BadRequest("Band name is required.");
        }
        logger.Information("Searching for bands with name {BandName}", bandName);
        var bandsList = await metalArchivesService.SearchBandsByName(bandName);
        return Ok(mapper.Map<List<BandDto>>(bandsList));
    }
    [HttpGet("band-details")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> GetBandDetails([FromQuery] string bandId, [FromQuery] string bandName)
    {
        if (string.IsNullOrEmpty(bandName))
        {
            logger.Error("Band name is required.");
            return BadRequest("Band name is required.");
        }
        logger.Information("Retrieving details for bands with name {BandName} and id {BandId}", bandName, bandId);
        var bandDetails = await metalArchivesService.GetBandDetails(bandId, bandName);
        return Ok(mapper.Map<BandDetailsDto>(bandDetails));
    }


}