using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Models;
using MyApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MyApp.IService;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    internal class Agg_DropDownModelViewModel : ObservableObject
    {
        private readonly IAgg_DropDownModelService _agg_DropDownModelService;

        private ObservableCollection<Agg_DropDownModelDTO> _ModelList;

        public ObservableCollection<Agg_DropDownModelDTO> StateList
        {
            get => _ModelList;
            set
            {
                _ModelList = value;
                OnPropertyChanged(nameof(StateList));
            }
        }

        public  Agg_DropDownModelViewModel(IAgg_DropDownModelService dropDownStateService)
        {
            _agg_DropDownModelService = dropDownStateService ?? throw new ArgumentNullException(nameof(dropDownStateService));
        }

        // Load data from the API
        public async Task LoadModelDetails()
        {
            try
            {
                var stateDetails = await _agg_DropDownModelService.GetModelData();

                switch (stateDetails)
                {
                    case IEnumerable<Agg_DropDownModelDTO> enumerableStateDetails:
                        StateList = new ObservableCollection<Agg_DropDownModelDTO>(enumerableStateDetails);
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
