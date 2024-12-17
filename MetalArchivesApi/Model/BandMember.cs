namespace MetalArchivesApi.Model;

public class BandMember(
    string Name,
    string Instrument
)
{
    public string Name { get; set; } = Name;
    public string Instrument { get; set; } = Instrument;
}