using System.Text.RegularExpressions;
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
        var bandElements = htmlDoc.DocumentNode.QuerySelector("div#band_stats").QuerySelectorAll("dt");
        var contryOfOriginElements = FindElementByDt(bandElements, "Country of origin");
        var countryCode = contryOfOriginElements.FirstChild.Attributes["href"].Value.Split("/").Last();
        var country = contryOfOriginElements.InnerText;
        var status = FindElementByDt(bandElements, "Status").InnerText;
        var location = FindElementByDt(bandElements, "Location").InnerText;
        var foundationYear = GetTextValue(FindElementByDt(bandElements, "Formed in"));
        var activeYears = GetTextValue(FindElementByDt(bandElements, "Years active"));
        var genre = GetTextValue(FindElementByDt(bandElements, "Genre"));
        var themes = GetTextValue(FindElementByDt(bandElements, "Themes"));
        var currentLabel = GetTextValue(FindElementByDt(bandElements, "Current label"));

        return new BandDetails(
            bandName,
            bandPhoto,
            bandLogo,
            country,
            countryCode,
            location,
            status,
            int.Parse(foundationYear),
            activeYears,
            genre,
            themes,
            currentLabel);
    }

    private static HtmlNode FindElementByDt(IList<HtmlNode> nodes, string dtText)
    {
        return nodes.FirstOrDefault(el => el.InnerText.Contains(dtText)).NextSibling.NextSibling;
    }

    private static string GetTextValue(HtmlNode node)
    {
        return Regex.Replace(node.InnerText, @"\s+", " ").Trim();
    }
}