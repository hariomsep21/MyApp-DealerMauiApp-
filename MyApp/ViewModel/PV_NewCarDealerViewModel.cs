using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;
using MyApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    internal class PV_NewCarDealerViewModel : ObservableObject
    {
        private readonly IPV_NewCarDealerService pV_NewCarDealerService;

        private ObservableCollection<PV_NewCarDealerDTO> _dueCustomer;

        public ObservableCollection<PV_NewCarDealerDTO> DueCustomer
        {
            get => _dueCustomer;
            set => SetProperty(ref _dueCustomer, value);
        }

        public PV_NewCarDealerViewModel(IPV_NewCarDealerService signUpService)
        {
            pV_NewCarDealerService = signUpService ?? throw new ArgumentNullException(nameof(signUpService));
            DueCustomer = new ObservableCollection<PV_NewCarDealerDTO>(); // Initialize the collection in the constructor
        }

        public async Task<bool> PostMobileNumberAsync(PV_NewCarDealerDTO newCarDetails)
        {
            try
            {
                return await pV_NewCarDealerService.PostMobileNumberAsync(newCarDetails);
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
