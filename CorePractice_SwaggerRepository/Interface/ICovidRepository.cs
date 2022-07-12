using CorePractice_SwaggerRepository.Models;

namespace CorePractice_SwaggerRepository.Interface;

public interface ICovidRepository
{
    Task<IEnumerable<CovidEntity>> Get();
}