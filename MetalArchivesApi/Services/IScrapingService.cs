using MetalArchivesApi.Model;

namespace MetalArchivesApi.Services;

public interface IScrapingService
{
    public BandDetails GetBandDetailsPage(string bandId, string bandName);
}