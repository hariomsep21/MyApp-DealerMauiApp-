using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MyApp.IService;
using MyApp.Models;
using MyApp.Service;

namespace MyApp.ViewModel
{
    public class BasicDetailsViewModel
    {
        private readonly IBasicDetailsService _basicDetailsService;

        public BasicDetailsViewModel(IBasicDetailsService basicDetailsService)
        {
            _basicDetailsService = basicDetailsService ?? throw new ArgumentNullException(nameof(basicDetailsService));
        }

        public async Task<bool> PostUserDetailsAsync(BasicDetailsDTO userDetails)
        {
            try
            {
                return await _basicDetailsService.PostUserDetails(userDetails);
            }
            catch (Exception ex)
            {
                // Log the error using a logging framework or Debug.WriteLine
                Debug.WriteLine($"Error posting user details: {ex.Message}");
                // Rethrow the exception for consistency
                throw;
            }
        }
    }
}
