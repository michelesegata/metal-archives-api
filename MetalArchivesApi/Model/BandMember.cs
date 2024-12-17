namespace MetalArchivesApi.Model;

public class BandMember(
    string name,
    string instrument
)
{
    public string Name { get; set; } = name;
    public string Instrument { get; set; } = instrument;
}