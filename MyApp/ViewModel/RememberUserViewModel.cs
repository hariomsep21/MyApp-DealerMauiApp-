using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyApp.IService;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    public partial class RememberUserViewModel : ObservableObject
    {
        private readonly IRememberUserService _rememberUserService;
        private RememberUserDTO selectedCustomer;

        public RememberUserDTO SelectedCustomer
        {
            get => selectedCustomer;
            set => SetProperty(ref selectedCustomer, value);
        }

        private ObservableCollection<RememberUserDTO> dueCustomer;

        public ObservableCollection<RememberUserDTO> DueCustomer
        {
            get => dueCustomer;
            set => SetProperty(ref dueCustomer, value);
        }

        public RememberUserViewModel(IRememberUserService rememberUserService)
        {
            _rememberUserService = rememberUserService ?? throw new ArgumentNullException(nameof(rememberUserService));
            DueCustomer = new ObservableCollection<RememberUserDTO>();
        }

        public async Task LoadRemembertStatus()
        {
            try
            {
                var paymentStatus = await _rememberUserService.RememberUserServices();

                if (paymentStatus is IEnumerable<RememberUserDTO> enumerablePaymentStatus)
                {
                    DueCustomer = new ObservableCollection<RememberUserDTO>(enumerablePaymentStatus);
                    SelectedCustomer = DueCustomer.Count > 0 ? DueCustomer[0] : null; // Set the first item as selected (modify as needed)
                }
               
                else
                {
                    // Handle unexpected type
                    Console.WriteLine($"Unexpected type: {paymentStatus?.GetType().FullName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        [RelayCommand]
        public async Task Back()
        {
            // Assuming Shell.Current.GoToAsync("//HomePage"); is a correct navigation call
            // If not, replace it with the actual navigation code
            await Shell.Current.GoToAsync("//HomePage");
        }
    }
}
