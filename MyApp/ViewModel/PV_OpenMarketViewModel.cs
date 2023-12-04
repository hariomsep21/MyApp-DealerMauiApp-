using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;
using MyApp.Service;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    internal class PV_OpenMarketViewModel : ObservableObject
    {
        private readonly IPV_OpenMarketService  pV_OpenMarketService;

        private ObservableCollection<PV_OpenMarketDTO> _dueOpenMarket;

        public ObservableCollection<PV_OpenMarketDTO> DueOpenMarket
        {
            get => _dueOpenMarket;
            set
            {
                SetProperty(ref _dueOpenMarket, value);
            }
        }

        public PV_OpenMarketViewModel(IPV_OpenMarketService signUpService)
        {
            pV_OpenMarketService = signUpService ?? throw new ArgumentNullException(nameof(signUpService));
            DueOpenMarket = new ObservableCollection<PV_OpenMarketDTO>(); // Initialize the collection in the constructor
        }

        public async Task<bool> OpenmarketMethod(PV_OpenMarketDTO newCarDetails)
        {
            try
            {
                return await pV_OpenMarketService.PostMobileNumberAsync(newCarDetails);
            }
            catch (Exception ex)
            {
                // Log the error using a logging framework or Debug.WriteLine
                Debug.WriteLine($"Error posting mobile number: {ex.Message}");
                // Rethrow the exception for consistency
                throw;
            }
        }
    }

}
