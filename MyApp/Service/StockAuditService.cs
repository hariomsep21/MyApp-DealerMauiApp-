using MyApp.IService;
using MyApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class StockAuditService:IStockAuditService
    {
        private readonly HttpClient _httpClient;
        public StockAuditService()
        {
            _httpClient = new HttpClient();
            // Additional configurations for HttpClient can be done here
        }
        public async  Task<List<UpcomingAuditModel>> GetUpcomingAudit()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://10.0.2.2:5137/api/stockAudit/upcoming");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var UpcomingDtos = JsonConvert.DeserializeObject<List<UpcomingAuditModel>>(responseBody);
                    return UpcomingDtos;

                }
                else
                {
                    // Handle non-success status codes
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception($"Exception: {ex.Message}");
            }
        }

        public async Task<List<UpcomingAuditModel>> GetPendingAudit()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://10.0.2.2:5137/api/stockAudit/pending");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var UpcomingDtos = JsonConvert.DeserializeObject<List<UpcomingAuditModel>>(responseBody);
                    return UpcomingDtos;

                }
                else
                {
                    // Handle non-success status codes
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception($"Exception: {ex.Message}");
            }
        }

        public async Task<List<UpcomingAuditModel>> GetAuditStatus()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://10.0.2.2:5137/api/stockAudit/stockstatus");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var Statusdto = JsonConvert.DeserializeObject<List<UpcomingAuditModel>>(responseBody);
                    return Statusdto;

                }
                else
                {
                    // Handle non-success status codes
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception($"Exception: {ex.Message}");
            }
        }

    }
    }

