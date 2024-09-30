using System.Text.Json.Serialization;

namespace MetalArchivesApi.Model;

public class ApiResponse
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    
    [JsonPropertyName("error")]
    public string Error { get; set; }
    
    [JsonPropertyName("iTotalRecords")]
    public int ITotalRecords { get; set; }
    
    [JsonPropertyName("iTotalDisplayRecords")]
    public int ITotalDisplayRecords { get; set; }
    
    [JsonPropertyName("sEcho")]
    public int SEcho { get; set; }
    
    [JsonPropertyName("aaData")]
    public List<List<string>> AaData { get; set; }
}