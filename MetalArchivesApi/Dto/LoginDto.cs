using System.Text.Json.Serialization;

namespace MetalArchivesApi.Dto;

public class LoginDto
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}