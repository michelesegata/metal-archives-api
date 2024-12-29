namespace MetalArchivesApi.Model;

public class Album(
    string title,
    int year,
    ReleaseType releaseType
    )
{
    public string Title { get; set; } = title;
    public int Year { get; set; } = year;
    public ReleaseType ReleaseType { get; set; } = releaseType;
}