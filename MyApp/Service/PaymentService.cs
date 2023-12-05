using MyApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.IService;

namespace MyApp.Services
{
    public class PaymentService : IPaymnetService
    {
        private readonly HttpClient _httpClient;

        public PaymentService()
        {
            _httpClient = new HttpClient();
            // Additional configurations for HttpClient can be done here
        }

        public async Task<List<PaymentDetailDto>> GetDuePayments()
        {
            // Your API logic here using HttpClient to fetch data
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://10.0.2.2:5137/api/Payment/due");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var paymentDtos = JsonConvert.DeserializeObject<List< PaymentDetailDto  >>(responseBody);
                    return paymentDtos;
                    
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
        public async Task<List<PaymentDetailDto>> GetPaymentStatus()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://10.0.2.2:5137/api/Payment/status");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var statusPay = JsonConvert.DeserializeObject<List<PaymentDetailDto>>(responseBody);
                    return statusPay;
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

        public async Task<List<PaymentDetailDto>> GetUpcomingPayment()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://10.0.2.2:5137/api/Payment/upcoming");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var statusPay = JsonConvert.DeserializeObject<List<PaymentDetailDto>>(responseBody);
                    return statusPay;
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
        public async Task<PaymentDetailDto> GetPaymentDetails(int paymentId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"http://10.0.2.2:5137/api/Payment/details/{paymentId}");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var paymentDetails = JsonConvert.DeserializeObject<PaymentDetailDto>(responseBody);
                    return paymentDetails;
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

    


