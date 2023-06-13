using LinkConnCounterWithRapidAPI.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class PhoneNumberValidateService
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;

    public PhoneNumberValidateService()
    {
        _client = new HttpClient();
        _configuration= new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }

    public async Task<PhoneNumberValidateModel> ValidatePhoneNumber()
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://phonenumbervalidatefree.p.rapidapi.com/ts_PhoneNumberValidateTest.jsp?number=%2B905393147493&country=UY"),
        };

        request.Headers.Add("X-RapidAPI-Key", _configuration["RapidApiKey"]);
        request.Headers.Add("X-RapidAPI-Host", _configuration["Phone:VerifyApiHost"]);

        using (var response = await _client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            PhoneNumberValidateModel model = JsonConvert.DeserializeObject<PhoneNumberValidateModel>(body);
            return model;
        }
    }

}
