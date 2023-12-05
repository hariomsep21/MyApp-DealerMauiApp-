// Service

using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Twilio.Types;
using MyApp.IService;

namespace MyApp.Service
{
    public class PostLogInService : IPostLogInService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://10.0.2.2:5137/api/LoginUserPhoneAPI/Login"; // URL for POST request

        public PostLogInService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

     
       public async Task<bool> PostLoginNumberAsync(string mobileNumber)
        {
            try
            {
                var requestBody = new StringContent(
                    JsonConvert.SerializeObject(new { PhoneNumber = mobileNumber }),
                    Encoding.UTF8,
                    "application/json"
                );

                using var response = await _httpClient.PostAsync($"{_baseUrl}", requestBody);

                if (response.IsSuccessStatusCode)
                {
                    // Assuming your response body is a JWT token
                    var token = await response.Content.ReadAsStringAsync();

                    // You can handle the token as needed (e.g., store it securely)
                    // For simplicity, I'm just printing it here
                    Console.WriteLine($"Token: {token}");

                    return true;
                }

                return false;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }


        public async Task<List<PhoneNumber>> GetPhoneNumbersAsync()
        {
            try
            {
                using var response = await _httpClient.GetAsync("https://localhost:7275/api/LoginUserPhoneAPI");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var phoneNumbers = JsonConvert.DeserializeObject<List<PhoneNumber>>(jsonResponse);
                    return phoneNumbers;
                }

                return null;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}
