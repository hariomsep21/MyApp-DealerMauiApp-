using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;
using MyApp.Service;
using System;
using System.Collections.Generic;
using MyApp.IService;
using System.Collections.ObjectModel;

namespace MyApp.ViewModel
{
    internal class Agg_DropDownYORegisViewModel : ObservableObject
    {
        private readonly IAgg_DropDownYORegisService _agg_DropDownYearOfRegService;

        private ObservableCollection<Agg_DropDownYORegisDTO> _YearOfRegServiceList;

        public ObservableCollection<Agg_DropDownYORegisDTO> YearOFList
        {
            get => _YearOfRegServiceList;
            set
            {
                _YearOfRegServiceList = value;
                OnPropertyChanged(nameof(YearOFList));
            }
        }

        public Agg_DropDownYORegisViewModel(IAgg_DropDownYORegisService dropDownStateService)
        {
            _agg_DropDownYearOfRegService = dropDownStateService ?? throw new ArgumentNullException(nameof(dropDownStateService));
        }

        // Load data from the API
        public async Task LoadYearOfRegDetails()
        {
            try
            {
                var stateDetails = await _agg_DropDownYearOfRegService.GetYearOfRegData();

                switch (stateDetails)
                {
                    case IEnumerable<Agg_DropDownYORegisDTO> enumerableStateDetails:
                        YearOFList = new ObservableCollection<Agg_DropDownYORegisDTO>(enumerableStateDetails);
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

