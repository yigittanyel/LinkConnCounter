using LinkConnCounterWithRapidAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LinkConnCounterWithRapidAPI.Services
{
    public class LinkedinService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public LinkedinService()
        {
            _httpClient = new HttpClient();
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        }

        public async Task<LinkedinGetConnectionModel> GetLinkedinConnections()
        {

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://linkedin-profiles-and-company-data.p.rapidapi.com/profile-details")
            };

            request.Headers.Add("X-RapidAPI-Key", _configuration["RapidApiKey"]);
            request.Headers.Add("X-RapidAPI-Host", _configuration["Linkedin:ApiHost"]);

            var jsonContent = @"{
            ""profile_id"": ""yigittanyel"",
            ""profile_type"": ""personal"",
            ""contact_info"": false,
            ""recommendations"": false,
            ""related_profiles"": false
        }";

            request.Content = new StringContent(jsonContent);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            LinkedinGetConnectionModel model = JsonConvert.DeserializeObject<LinkedinGetConnectionModel>(responseBody);
            return model;
        }
    }
}
