using MyApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyApp.IService;
using System.Threading.Tasks;

namespace MyApp.Service
{
    internal class Agg_DropDownYORegisService : IAgg_DropDownYORegisService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiLogUrl = "http://10.0.2.2:5137/api/PVA_YearOfRegAPI";

        public Agg_DropDownYORegisService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<IEnumerable<Agg_DropDownYORegisDTO>> GetYearOfRegData()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseApiLogUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var YearDtos = JsonConvert.DeserializeObject<List<Agg_DropDownYORegisDTO>>(responseBody);
                        return YearDtos ?? new List<Agg_DropDownYORegisDTO>();
                    }
                    catch (JsonSerializationException)
                    {
                        var YearDto = JsonConvert.DeserializeObject<Agg_DropDownYORegisDTO>(responseBody);
                        return YearDto != null ? new List<Agg_DropDownYORegisDTO> { YearDto } : new List<Agg_DropDownYORegisDTO>();
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
