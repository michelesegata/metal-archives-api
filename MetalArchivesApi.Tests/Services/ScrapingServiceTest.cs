using System.Linq;
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
        Assert.Equal(3, bandDetails.BandMembers.Count);
        Assert.Equal("Ron Royce", bandDetails.BandMembers.First().Name);
        Assert.Equal("Bass (1984-1996, 2010-present), Vocals (1985-1996, 2010-present)", bandDetails.BandMembers.First().Instrument);
        Assert.Equal("Tommy T. Baron", bandDetails.BandMembers[1].Name);
        Assert.Equal("Guitars (1985-1996, 2010-present)", bandDetails.BandMembers[1].Instrument);
        Assert.Equal("Diego Rapacchietti", bandDetails.BandMembers[2].Name);
        Assert.Equal("Drums (2014-present)", bandDetails.BandMembers[2].Instrument);
    }

    [Fact]
    public void GetBandDetailsPageWithoutPhoto_ReturnData()
    {
        var bandDetails = _sut.GetBandDetailsPage("3540490346", "Éla");
        Assert.NotNull(bandDetails);
        Assert.Equal("Éla", bandDetails.BandName);
        Assert.Null(bandDetails.BandPhoto);
        Assert.Equal("https://www.metal-archives.com/images/3/5/4/0/3540490346_logo.png?4747", bandDetails.BandLogo);
        Assert.Equal("Italy", bandDetails.Country);
        Assert.Equal("IT", bandDetails.CountryCode);
        Assert.Equal("Active", bandDetails.Status);
        Assert.Equal(2017, bandDetails.FoundationYear);
        Assert.Equal("2017-present", bandDetails.ActivityYears);
        Assert.Equal("Doom/Death Metal", bandDetails.Genre);
        Assert.Equal("N/A", bandDetails.Themes);
        Assert.Equal("Endless Winter", bandDetails.CurrentLabel);
    }
}