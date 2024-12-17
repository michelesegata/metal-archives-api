using JetBrains.Annotations;
using MetalArchivesApi.Services;
using Xunit;

namespace MetalArchivesApi.Tests.Services;

[TestSubject(typeof(ScrapingService))]
public class ScrapingServiceTest
{

    private readonly ScrapingService _sut = new(new Serilog.LoggerConfiguration().CreateLogger());

    [Fact]
    public void GetBandDetailsPage_ReturnData()
    {
        var bandDetails = _sut.GetBandDetailsPage("117", "Coroner");
        Assert.NotNull(bandDetails);
        Assert.Equal("Coroner", bandDetails.BandName);
        Assert.Equal("https://www.metal-archives.com/images/1/1/7/117_photo.jpg?3316", bandDetails.BandPhoto);
        Assert.Equal("https://www.metal-archives.com/images/1/1/7/117_logo.jpg?0428", bandDetails.BandLogo);
        Assert.Equal("Switzerland", bandDetails.Country);
        Assert.Equal("CH", bandDetails.CountryCode);
        Assert.Equal("Active", bandDetails.Status);
        Assert.Equal(1983, bandDetails.FoundationYear);
        Assert.Equal("1983 (as VoltAge), 1983-1985, 1985-1996, 2010-present", bandDetails.ActivityYears);
        Assert.Equal("Technical Thrash Metal", bandDetails.Genre);
        Assert.Equal("Death, Dreamstates, Depression, Politics, Hate", bandDetails.Themes);
        Assert.Equal("Century Media Records", bandDetails.CurrentLabel);
    }
}