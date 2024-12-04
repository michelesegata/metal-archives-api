using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using MetalArchivesApi.Model;
using ILogger = Serilog.ILogger;

namespace MetalArchivesApi.Services;

public class ScrapingService(
    ILogger logger) : IScrapingService
{

    public BandDetails GetBandDetailsPage(string bandId, string bandName)
    {
        logger.Information($"Scraping band details for {bandName}");
        var html = $"http://www.metal-archives.com/bands/{bandName}/{bandId}";
        HtmlWeb web = new HtmlWeb();
        var htmlDoc = web.Load(html);

        var bandPhoto = htmlDoc.DocumentNode.QuerySelector("a#photo")?.Attributes["href"]?.Value;
        var bandLogo = htmlDoc.DocumentNode.QuerySelector("a#logo")?.Attributes["href"]?.Value;

        BandDetails bandDetails = new BandDetails(
            bandName,
            bandPhoto,
            bandLogo,
            "Switzerland",
            "Zurich",
            "Active",
            1983,
            "1983-present",
            "Techinical Thrash Metal",
            "Technology, Science",
            "Century Media Records");

        return bandDetails;
    }
}