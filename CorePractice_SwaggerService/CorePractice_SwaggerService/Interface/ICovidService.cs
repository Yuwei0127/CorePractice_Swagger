using CorePractice_SwaggerService.Dtos;

namespace CorePractice_SwaggerService.Interface;

public interface ICovidService
{
    /// <summary>
    /// 取得臺中市確診數量資訊
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CovidDto>> Get();
}