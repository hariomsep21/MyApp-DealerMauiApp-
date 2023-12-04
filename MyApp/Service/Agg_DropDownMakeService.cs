using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service
{
    internal class Agg_DropDownMakeService : IAgg_DropDownMakeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiLogUrl = "http://10.0.2.2:5137/api/PVA_MakeAPI";

        public Agg_DropDownMakeService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

      
        public async Task<IEnumerable<Agg_DropDownMakeDTO>> GetMakeData()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseApiLogUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var makeDtos = JsonConvert.DeserializeObject<List<Agg_DropDownMakeDTO>>(responseBody);
                        return makeDtos ?? new List<Agg_DropDownMakeDTO>();
                    }
                    catch (JsonSerializationException)
                    {
                        var makeDto = JsonConvert.DeserializeObject<Agg_DropDownMakeDTO>(responseBody);
                        return makeDto != null ? new List<Agg_DropDownMakeDTO> { makeDto } : new List<Agg_DropDownMakeDTO>();
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
