namespace MetalArchivesApi.Model;

public class BandDetails(
    string bandName,
    string bandPhoto,
    string bandLogo,
    string country,
    string countryCode,
    string location,
    string status,
    int foundationYear,
    string activityYears,
    string genre,
    string themes,
    string currentLabel)
{
    public string BandName { get; set; } = bandName;
    public string BandPhoto { get; set; } = bandPhoto;
    public string BandLogo { get; set; } = bandLogo;
    public string Country { get; set; } = country;
    public string CountryCode { get; set; } = countryCode;
    public string Location { get; set; } = location;
    public string Status { get; set; } = status;
    public int FoundationYear { get; set; } = foundationYear;
    public string ActivityYears { get; set; } = activityYears;
    public string Genre { get; set; } = genre;
    public string Themes { get; set; } = themes;
    public string CurrentLabel { get; set; } = currentLabel;
}