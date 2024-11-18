namespace MetalArchivesApi.Services;

public interface IJwtService
{
    public string GenerateJwtToken(string userId);
}