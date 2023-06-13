using LinkConnCounterWithRapidAPI.Models;
using Newtonsoft.Json;
using System;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public WeatherService()
    {
        _httpClient = new HttpClient();
        _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }

    public async Task<WeatherModel> GetWeatherForecast(double latitude, double longitude)
    {
        var apiUrl = $"https://weatherbit-v1-mashape.p.rapidapi.com/forecast/3hourly?lat={latitude}&lon={longitude}&lang=tr";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(apiUrl),
            Headers =
            {
                { "X-RapidAPI-Key", _configuration["RapidApiKey"] },
                { "X-RapidAPI-Host", _configuration["Weather:ApiHost"] },
            },
        };

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();
        WeatherModel model = JsonConvert.DeserializeObject<WeatherModel>(responseBody);
        return model;
    }
}
