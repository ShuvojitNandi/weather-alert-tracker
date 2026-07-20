using System.Net.Http;

namespace WeatherAlertTracker.Infrastructure.Weather;

public class WeatherClient
{
    private readonly HttpClient _httpClient;

    public WeatherClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}