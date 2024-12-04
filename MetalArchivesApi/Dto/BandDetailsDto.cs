using System.Text.Json.Serialization;

namespace MetalArchivesApi.Dto;

public class BandDetailsDto(
    string bandName,
    string bandPhoto,
    string bandLogo,
    string country,
    string location,
    string status,
    int foundationYear,
    string activityYears,
    string genre,
    string themes,
    string currentLabel)
{
    [JsonPropertyName("bandName")]
    public string BandName { get; set; } = bandName;
    [JsonPropertyName("bandPhoto")]
    public string BandPhoto { get; set; } = bandPhoto;
    [JsonPropertyName("bandName")]
    public string BandLogo { get; set; } = bandLogo;
    [JsonPropertyName("country")]
    public string Country { get; set; } = country;
    [JsonPropertyName("location")]
    public string Location { get; set; } = location;
    [JsonPropertyName("status")]
    public string Status { get; set; } = status;
    [JsonPropertyName("foundationYear")]
    public int FoundationYear { get; set; } = foundationYear;
    [JsonPropertyName("activityYears")]
    public string ActivityYears { get; set; } = activityYears;
    [JsonPropertyName("genre")]
    public string Genre { get; set; } = genre;
    [JsonPropertyName("themes")]
    public string Themes { get; set; } = themes;
    [JsonPropertyName("currentLabel")]
    public string CurrentLabel { get; set; } = currentLabel;
}