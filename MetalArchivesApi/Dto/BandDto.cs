using System.Text.Json.Serialization;

namespace MetalArchivesApi.Dto;

public class BandDto
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("genre")]
    public string Genre { get; set; }
    [JsonPropertyName("country")]
    public string Country { get; set; }
}