using MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;
using System.Text.Json;

namespace MoGYSD.Services;
public class PersonApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _securityKey;

    public PersonApiService(string baseUrl, string securityKey)
    {
        _httpClient = new HttpClient();
        _baseUrl = baseUrl.TrimEnd('/');
        _securityKey = securityKey;
    }

    public async Task<PersonResponse> GetPersonByIdAsync(string idNumber)
    {
        var requestUrl = $"{_baseUrl}/apiService.svc/GetPersonByID?key={_securityKey}&idNumber={idNumber}";

        var response = await _httpClient.GetAsync(requestUrl);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        // Deserialize JSON to PersonResponse
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var person = JsonSerializer.Deserialize<PersonResponse>(content, options);

        return person;
    }
}
