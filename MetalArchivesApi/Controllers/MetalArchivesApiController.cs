using AutoMapper;
using MetalArchivesApi.Dto;
using MetalArchivesApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MetalArchivesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetalArchivesApiController(
    IMetalArchivesService metalArchivesService,
    UserManager<IdentityUser> userManager,
    IJwtService jwtService,
    IMapper mapper)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var user = await userManager.FindByNameAsync(model.Username);
        if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
        {
            return Unauthorized();
        }

        var token = jwtService.GenerateJwtToken(user.Id);
        return Ok(new { token });
    }

    [HttpGet("search")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> SearchBandsByName([FromQuery] string bandName)
    {
        if (string.IsNullOrEmpty(bandName))
        {
            return BadRequest("Band name is required.");
        }

        var bandsList = await metalArchivesService.SearchBandsByName(bandName);
        return Ok(mapper.Map<List<BandDto>>(bandsList));
    }

}