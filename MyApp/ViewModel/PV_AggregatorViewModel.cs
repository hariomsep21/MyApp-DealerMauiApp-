using MvvmHelpers;
using MyApp.IService;
using MyApp.Models;
using MyApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    internal class PV_AggregatorViewModel : ObservableObject
    {
        private readonly IPV_AggregatorService _pvAggregatorService;
        private PV_AggregatorDTO _selectedCustomer;

        public PV_AggregatorDTO SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        public PV_AggregatorViewModel(IPV_AggregatorService pvAggregatorService)
        {
            _pvAggregatorService = pvAggregatorService;
        }

        private ObservableCollection<PV_AggregatorDTO> _dueCustomers;

        public ObservableCollection<PV_AggregatorDTO> DueCustomers
        {
            get => _dueCustomers;
            set
            {
                _dueCustomers = value;
                OnPropertyChanged(nameof(DueCustomers));
            }
        }

        // Modify the LoadPaymentStatus method to use PostAggregatorDetails
        public async Task LoadPaymentStatus()
        {
            try
            {
                var paymentStatus = await _pvAggregatorService.PostAggregatorDetails();

                switch (paymentStatus)
                {
                    case IEnumerable<PV_AggregatorDTO> enumerablePaymentStatus:
                        DueCustomers = new ObservableCollection<PV_AggregatorDTO>(enumerablePaymentStatus);
                        SelectedCustomer = DueCustomers.FirstOrDefault(); // Set the first item as selected (modify as needed)
                        break;

                    // Add other cases if needed for different response types

                    default:
                        // Handle unexpected type
                        Console.WriteLine($"Unexpected type: {paymentStatus?.GetType().FullName}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
