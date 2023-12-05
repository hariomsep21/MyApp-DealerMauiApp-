using MyApp.IService;
using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service
{
    internal class PV_AggregatorService : IPV_AggregatorService
    {
        private readonly HttpClient _httpClient;
        public PV_AggregatorService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<PV_AggregatorDTO>> PostAggregatorDetails()
        {
            try
            {
                // You may need to adjust the URL and request content based on your API requirements
                HttpResponseMessage response = await _httpClient.PostAsync("http://10.0.2.2:5137/api/PV_AggregatorAPI/Post", null);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Use a try-catch block to handle both array and single object cases
                    try
                    {
                        var pvAggregatorDtos = JsonConvert.DeserializeObject<List<PV_AggregatorDTO>>(responseBody);

                        // For simplicity, assuming you want to return the entire list
                        return pvAggregatorDtos ?? new List<PV_AggregatorDTO>();
                    }
                    catch (JsonSerializationException)
                    {
                        // If deserialization as a list fails, attempt deserialization as a single object
                        var pvAggregatorDto = JsonConvert.DeserializeObject<PV_AggregatorDTO>(responseBody);
                        return pvAggregatorDto != null ? new List<PV_AggregatorDTO> { pvAggregatorDto } : new List<PV_AggregatorDTO>();
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
