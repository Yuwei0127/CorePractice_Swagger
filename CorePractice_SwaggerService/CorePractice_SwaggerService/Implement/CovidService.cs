using CorePractice_SwaggerRepository.Interface;
using CorePractice_SwaggerService.Dtos;
using CorePractice_SwaggerService.Interface;

namespace CorePractice_SwaggerService.Implement;

public class CovidService:ICovidService
{
    private readonly ICovidRepository _covidRepository;

    public CovidService(ICovidRepository covidRepository)
    {
        _covidRepository = covidRepository;
    }
    
    public async Task<IEnumerable<CovidDto>> Get()
    {
        // 取得確診資訊
        var entities = await _covidRepository.Get();

        var dtos = entities.Select(x => new CovidDto
        {
            Date = x.Date,
            DiagnosedCountOriginTW = x.DiagnosedCountOriginTW,
            DiagnosedCountForeignTW = x.DiagnosedCountForeignTW,
            DiagnosedCountOriginTaichung = x.DiagnosedCountOriginTaichung,
            DiagnosedCountForeignTaichung = x.DiagnosedCountForeignTaichung
        });

        return dtos;
    }
}