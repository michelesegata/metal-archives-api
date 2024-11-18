using MetalArchivesApi.Model.Auth;
using MetalArchivesApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MetalArchivesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetalArchivesApiController : ControllerBase
{
    private readonly IMetalArchivesService _metalArchivesService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IJwtService _jwtService;

    public MetalArchivesApiController(IMetalArchivesService metalArchivesService, UserManager<IdentityUser> userManager, IJwtService jwtService)
    {
        _metalArchivesService = metalArchivesService;
        _jwtService = jwtService;
        _userManager = userManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return Unauthorized();
        }

        var token = _jwtService.GenerateJwtToken(user.Id);
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

        var result = await _metalArchivesService.SearchBandsByName(bandName);
        return Ok(result);
    }

}