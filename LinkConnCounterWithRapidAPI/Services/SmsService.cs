using System.Net.Http;
using System.Threading.Tasks;

public class SmsService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public SmsService()
    {
        _httpClient = new HttpClient();
        _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    }

    public async Task<string> SendSmsAsync(string phoneNumber, string message)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://inteltech.p.rapidapi.com/send.php"),
            Headers =
            {
                { "X-RapidAPI-Key", _configuration["RapidApiKey"]},
                { "X-RapidAPI-Host", _configuration["Phone:SmsApiHost"]},
            },
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "sms", phoneNumber },
                { "message", message },
                { "key", _configuration["Phone:SmsApiKey"] },
                { "username", "yigittanyel" },
            })
        };

        using (var response = await _httpClient.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
