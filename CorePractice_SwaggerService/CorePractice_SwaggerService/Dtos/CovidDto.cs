namespace CorePractice_SwaggerService.Dtos;

public class CovidDto
{
    /// <summary>
    /// 日期
    /// </summary>
    public string Date { get; set; }

    /// <summary>
    /// 全臺確診數_本土
    /// </summary>
    public string DiagnosedCountOriginTW { get; set; }
    
    /// <summary>
    /// 全臺確診數_境外
    /// </summary>
    public string DiagnosedCountForeignTW { get; set; }

    /// <summary>
    /// 臺中市確診數_本土
    /// </summary>
    public string DiagnosedCountOriginTaichung { get; set; }
    
    /// <summary>
    /// 臺中市確診數_境外
    /// </summary>
    public string DiagnosedCountForeignTaichung { get; set; }
}