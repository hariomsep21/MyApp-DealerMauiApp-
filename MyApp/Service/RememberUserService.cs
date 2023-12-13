using MyApp.IService;
using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service
{
    internal class RememberUserService : IRememberUserService
    {
        private readonly HttpClient _httpClient;

        public RememberUserService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<CustomerSupportDTO>> RememberUserServices()
        {
            try
            {
                string jwtToken = await SecureStorage.GetAsync("JWTToken");
                // Set up HttpClient (base URL, headers, etc.) for your API calls
                if (!string.IsNullOrEmpty(jwtToken))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
                }
                HttpResponseMessage response = await _httpClient.GetAsync("http://10.0.2.2:5137/api/RememberConditionAPI");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Check if the response is an array or a single object
                    if (responseBody.StartsWith("["))
                    {
                        var customerDtos = JsonConvert.DeserializeObject<List<CustomerSupportDTO>>(responseBody);

                        // For simplicity, return the entire list
                        return customerDtos;
                    }
                    else
                    {
                        var customerDto = JsonConvert.DeserializeObject<CustomerSupportDTO>(responseBody);

                        // Return a list containing the single item
                        return new List<CustomerSupportDTO> { customerDto };
                    }
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message}");
            }
        }

      
    }
}
