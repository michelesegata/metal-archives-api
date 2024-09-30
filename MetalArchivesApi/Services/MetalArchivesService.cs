using System.Text.Json;
using System.Text.RegularExpressions;
using MetalArchivesApi.Model;

namespace MetalArchivesApi.Services;

public class MetalArchivesService : IMetalArchivesService
{
    private readonly HttpClient _httpClient;

    public MetalArchivesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Band>> SearchBandsByName(string bandName)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"https://www.metal-archives.com/search/ajax-band-search/?field=name&query={bandName}");
        request.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36");
        using HttpResponseMessage response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonResponse);
        var bands = apiResponse.AaData.Select(data =>
        {
            var idMatch = Regex.Match(data[0], @"\/bands\/.*?\/(\d+)");
            var id = idMatch.Success ? long.Parse(idMatch.Groups[1].Value) : 0;

            return new Band
            {
                Id = id,
                Name = Regex.Replace(data[0], "<.*?>", string.Empty).Trim(),
                Genre = data[1],
                Country = data[2]
            };
        }).ToList();
        return bands;
    }
}