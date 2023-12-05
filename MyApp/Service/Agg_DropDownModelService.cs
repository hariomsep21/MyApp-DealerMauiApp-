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
    internal class Agg_DropDownModelService : IAgg_DropDownModelService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiLogUrl = "http://10.0.2.2:5137/api/PVA_ModelAPI";

        public Agg_DropDownModelService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }


        public async Task<IEnumerable<Agg_DropDownModelDTO>> GetModelData()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseApiLogUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var modelDtos = JsonConvert.DeserializeObject<List<Agg_DropDownModelDTO>>(responseBody);
                        return modelDtos ?? new List<Agg_DropDownModelDTO>();
                    }
                    catch (JsonSerializationException)
                    {
                        var modelDto = JsonConvert.DeserializeObject<Agg_DropDownModelDTO>(responseBody);
                        return modelDto != null ? new List<Agg_DropDownModelDTO> { modelDto } : new List<Agg_DropDownModelDTO>();
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
