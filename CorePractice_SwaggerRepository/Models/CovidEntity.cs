using System.Text.Json.Serialization;

namespace CorePractice_SwaggerRepository.Models;

public class CovidEntity
{
    /// <summary>
    /// 日期
    /// </summary>
    [JsonPropertyName("日期")]
    public string Date { get; set; }

    /// <summary>
    /// 全臺確診數_本土
    /// </summary>
    [JsonPropertyName("全臺確診數_本土")]
    public string DiagnosedCountOriginTW { get; set; }
    
    /// <summary>
    /// 全臺確診數_境外
    /// </summary>
    [JsonPropertyName("全臺確診數_境外")]
    public string DiagnosedCountForeignTW { get; set; }

    /// <summary>
    /// 臺中市確診數_本土
    /// </summary>
    [JsonPropertyName("臺中市確診數_本土")]
    public string DiagnosedCountOriginTaichung { get; set; }
    
    /// <summary>
    /// 臺中市確診數_境外
    /// </summary>
    [JsonPropertyName("臺中市確診數_境外")]
    public string DiagnosedCountForeignTaichung { get; set; }
}