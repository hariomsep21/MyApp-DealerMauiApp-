using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;
using MyApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    internal class DropDownStateViewModel : ObservableObject
    {
        private readonly IDropDownStateService _dropDownStateService;

        private ObservableCollection<DropDownStateDTO> _stateList;

        public ObservableCollection<DropDownStateDTO> StateList
        {
            get => _stateList;
            set
            {
                _stateList = value;
                OnPropertyChanged(nameof(StateList));
            }
        }

        public DropDownStateViewModel(IDropDownStateService dropDownStateService)
        {
            _dropDownStateService = dropDownStateService ?? throw new ArgumentNullException(nameof(dropDownStateService));
        }

        // Load data from the API
        public async Task LoadStateDetails()
        {
            try
            {
                var stateDetails = await _dropDownStateService.GetState();

                switch (stateDetails)
                {
                    case IEnumerable<DropDownStateDTO> enumerableStateDetails:
                        StateList = new ObservableCollection<DropDownStateDTO>(enumerableStateDetails);
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
