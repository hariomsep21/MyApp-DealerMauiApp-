using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service
{

    public class LoginUserPhoneServicecs : ILoginUserPhoneServicecs
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiLogUrl = "http://10.0.2.2:5137/api/LoginUserPhoneAPI";

        public LoginUserPhoneServicecs(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<LoginUserPhoneDTO>> LoginDetails()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseApiLogUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var customerDtos = JsonConvert.DeserializeObject<List<LoginUserPhoneDTO>>(responseBody);
                        return customerDtos ?? new List<LoginUserPhoneDTO>();
                    }
                    catch (JsonSerializationException)
                    {
                        var customerDto = JsonConvert.DeserializeObject<LoginUserPhoneDTO>(responseBody);
                        return customerDto != null ? new List<LoginUserPhoneDTO> { customerDto } : new List<LoginUserPhoneDTO>();
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

      
    }
}
