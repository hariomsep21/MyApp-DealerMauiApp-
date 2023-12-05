using MyApp.IService;
using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp.Service
{
    internal class DropDownStateService : IDropDownStateService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiLogUrl = "http://10.0.2.2:5137/api/StateAPI";

        public DropDownStateService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<DropDownStateDTO>> GetState()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseApiLogUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var stateDtos = JsonConvert.DeserializeObject<List<DropDownStateDTO>>(responseBody);
                        return stateDtos ?? new List<DropDownStateDTO>();
                    }
                    catch (JsonSerializationException)
                    {
                        var stateDto = JsonConvert.DeserializeObject<DropDownStateDTO>(responseBody);
                        return stateDto != null ? new List<DropDownStateDTO> { stateDto } : new List<DropDownStateDTO>();
                    }
                }
                else
                {
                    // Include additional information about the error, such as the URL or response content
                    throw new HttpRequestException($"Error: {response.StatusCode}. Response: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Include additional information about the error, such as the URL
                throw new HttpRequestException($"HTTP request error: {ex.Message}. URL: {_baseApiLogUrl}");
            }
            catch (Exception ex)
            {
                // Include additional information about the error, such as the URL
                throw new Exception($"Exception: {ex.Message}. URL: {_baseApiLogUrl}");
            }
        }
    }
}
