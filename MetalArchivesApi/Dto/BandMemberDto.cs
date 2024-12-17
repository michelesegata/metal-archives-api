using System.Text.Json.Serialization;

namespace MetalArchivesApi.Dto;

public class BandMemberDto(
    string name,
    string instrument
)
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = name;
    [JsonPropertyName("instrument")]
    public string Instrument { get; set; } = instrument;
}