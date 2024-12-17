using MetalArchivesApi.Model;

namespace MetalArchivesApi.Services;

public interface IMetalArchivesService
{
    Task<List<Band>> SearchBandsByName(string bandName);
    Task<BandDetails> GetBandDetails(string bandId, string bandName);
}