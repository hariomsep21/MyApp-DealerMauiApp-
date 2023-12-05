using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;
using MyApp.Service;
using MyApp.IService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    internal class Agg_DropDownMakeViewModel : ObservableObject
    {
        private readonly IAgg_DropDownMakeService  _agg_DropDownMakeService;

        private ObservableCollection<Agg_DropDownMakeDTO> _makeList;

        public ObservableCollection<Agg_DropDownMakeDTO> StateList
        {
            get => _makeList;
            set
            {
                _makeList = value;
                OnPropertyChanged(nameof(StateList));
            }
        }

        public Agg_DropDownMakeViewModel(IAgg_DropDownMakeService dropDownStateService)
        {
            _agg_DropDownMakeService = dropDownStateService ?? throw new ArgumentNullException(nameof(dropDownStateService));
        }

        // Load data from the API
        public async Task LoadMakeDetails()
        {
            try
            {
                var stateDetails = await _agg_DropDownMakeService.GetMakeData();

                switch (stateDetails)
                {
                    case IEnumerable<Agg_DropDownMakeDTO> enumerableStateDetails:
                        StateList = new ObservableCollection<Agg_DropDownMakeDTO>(enumerableStateDetails);
                        // Log successful loading
                        Console.WriteLine("State details loaded successfully.");
                        break;

                    default:
                        // Handle unexpected type
                        Console.WriteLine($"Unexpected type: {stateDetails?.GetType().FullName}");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Log the error using a logging framework
                Console.WriteLine($"Error loading state details: {ex.Message}");
                throw; // Rethrow the exception for consistency
            }
        }
    }
}
