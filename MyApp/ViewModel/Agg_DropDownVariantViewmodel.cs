using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;
using MyApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyApp.ViewModel
{
    internal class Agg_DropDownVariantViewmodel : ObservableObject
    {
        private readonly IAgg_DropDownVariantService _agg_DropDownModelService;

        private ObservableCollection<Agg_DropDownVariantDTO> _stateList;

        public ObservableCollection<Agg_DropDownVariantDTO> StateList
        {
            get => _stateList;
            set
            {
                _stateList = value;
                OnPropertyChanged(nameof(StateList));
            }
        }

        public Agg_DropDownVariantViewmodel(IAgg_DropDownVariantService dropDownStateService)
        {
            _agg_DropDownModelService = dropDownStateService ?? throw new ArgumentNullException(nameof(dropDownStateService));
        }

        // Load data from the API
        public async Task LoadVariantDetails()
        {
            try
            {
                var stateDetails = await _agg_DropDownModelService.GetVariantData();

                switch (stateDetails)
                {
                    case IEnumerable<Agg_DropDownVariantDTO> enumerableStateDetails:
                        StateList = new ObservableCollection<Agg_DropDownVariantDTO>(enumerableStateDetails);
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
