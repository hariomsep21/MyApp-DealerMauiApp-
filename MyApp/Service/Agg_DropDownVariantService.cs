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
    internal class Agg_DropDownVariantService : IAgg_DropDownVariantService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiLogUrl = "http://10.0.2.2:5137/api/PVA_VariantAPI";

        public Agg_DropDownVariantService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<Agg_DropDownVariantDTO>> GetVariantData()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_baseApiLogUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    try
                    {
                        var variantDtos = JsonConvert.DeserializeObject<List<Agg_DropDownVariantDTO>>(responseBody);
                        return variantDtos ?? new List<Agg_DropDownVariantDTO>();
                    }
                    catch (JsonSerializationException)
                    {
                        var variantDto = JsonConvert.DeserializeObject<Agg_DropDownVariantDTO>(responseBody);
                        return variantDto != null ? new List<Agg_DropDownVariantDTO> { variantDto } : new List<Agg_DropDownVariantDTO>();
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
