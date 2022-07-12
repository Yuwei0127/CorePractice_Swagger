using CorePractice_SwaggerRepository.Interface;
using System.Net.Http;
using System.Text.Json;
using CorePractice_SwaggerRepository.Models;

namespace CorePractice_SwaggerRepository.Implement;

public class CovidRepository:ICovidRepository
{
    private readonly string  CovidTaichungUrl = "https://datacenter.taichung.gov.tw/swagger/OpenData/c304456b-f0ab-4212-8bef-a275be6b3671";
    private readonly IHttpClientFactory _httpClientFactory;
    
    public CovidRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IEnumerable<CovidEntity>> Get()
    {
        // https://data.gov.tw/dataset/152678
        // https://datacenter.taichung.gov.tw/swagger/OpenData/c304456b-f0ab-4212-8bef-a275be6b3671
        
        var httpClient = _httpClientFactory.CreateClient("Covid");

        try
        {

            var response = await httpClient.GetAsync(CovidTaichungUrl);
        
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<CovidEntity>();
            }

            var content = await response.Content.ReadAsStringAsync();
            
            var result = JsonSerializer.Deserialize<IEnumerable<CovidEntity>>(content);

            if (result.Any().Equals(false))
            {
                return Enumerable.Empty<CovidEntity>();
            }
        
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}