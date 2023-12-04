using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service
{
    public class SignUpService : ISignUpService
    {
        private readonly HttpClient _httpClient;
        private readonly string _getMobileNumberApiUrl = "http://10.0.2.2:5137/api/UserPhoneAPI/SignGet"; // URL for GET request
        private readonly string _postMobileNumberApiUrl = "http://10.0.2.2:5137/api/UserPhoneAPI"; // URL for POST request

        public SignUpService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<SignUpDTO>> GetMobileNumberAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_getMobileNumberApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var customerDtos = JsonConvert.DeserializeObject<List<SignUpDTO>>(responseBody);
                        return customerDtos ?? new List<SignUpDTO>();
                    }
                    catch (JsonSerializationException)
                    {
                        var customerDto = JsonConvert.DeserializeObject<SignUpDTO>(responseBody);
                        return customerDto != null ? new List<SignUpDTO> { customerDto } : new List<SignUpDTO>();
                    }
                }
                else
                {
                    throw new HttpRequestException($"Error: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"HTTP request error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Exception: {ex.Message}");
            }
        }

        // ...

        public async Task<bool> PostMobileNumberAsync(string mobileNumber)
        {
            try
            {
                var requestBody = new StringContent(
                    JsonConvert.SerializeObject(new SignUpDTO { PhoneNumber = mobileNumber }),
                    Encoding.UTF8,
                    "application/json"
                );

                using HttpResponseMessage response = await _httpClient.PostAsync(_postMobileNumberApiUrl, requestBody);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Bad Request: {errorContent}");

                    // Parse the JSON error content into a structured object
                    var problemDetails = JsonConvert.DeserializeObject<ProblemDetails>(errorContent);

                    // Example: Display specific error message to the user
                    Console.WriteLine($"Bad Request: Error: {problemDetails.Title}. {problemDetails.Detail}");

                    return false;
                }
                else
                {
                    response.EnsureSuccessStatusCode(); // Re-throw for other non-success status codes
                    return false; // This line might not be reached, depending on the response status code
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP request error: {ex.Message}");
                // Assuming this is a mobile app, use the appropriate method for displaying alerts or logging
                // e.g., DisplayAlert("Request Error", $"HTTP request error: {ex.Message}", "OK");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                // Assuming this is a mobile app, use the appropriate method for displaying alerts or logging
                // e.g., DisplayAlert("Error", $"Exception: {ex.Message}", "OK");
                return false;
            }
        }


        // ...


        // Create a class to represent the Problem Details structure
        public class ProblemDetails
        {
            public string Title { get; set; }
            public string Detail { get; set; }
            // Add other properties if the Problem Details response contains more details
        }

    }
}
