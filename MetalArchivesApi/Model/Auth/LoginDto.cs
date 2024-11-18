using System.Text.Json.Serialization;

namespace MetalArchivesApi.Model.Auth;

public class LoginDto
{
    [JsonPropertyName("username")]
    public string Username { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
}