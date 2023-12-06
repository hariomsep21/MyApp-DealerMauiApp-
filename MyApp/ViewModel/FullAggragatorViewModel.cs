using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.IService;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    internal class FullAggragatorViewModel : ObservableObject
    {
        private readonly IFullAggragatorService _aggService;


        private ObservableCollection<Agg_DropDownMakeDTO> _makeList;
        private ObservableCollection<Agg_DropDownModelDTO> _modelList;
        private ObservableCollection<Agg_DropDownVariantDTO> _variantList;
        private ObservableCollection<Agg_DropDownYORegisDTO> _yearOfRegServiceList;
        private ObservableCollection<PV_NewCarDealerDTO> _NewCarDealerDTOs;
        private ObservableCollection<PV_OpenMarketDTO> _OpenMarketDTOs;
        private ObservableCollection<PV_AggregatorDTO> _AggregatorDTOs;


        private Agg_DropDownMakeDTO _selectedMake;
        private Agg_DropDownModelDTO _selectedModel;
        private Agg_DropDownYORegisDTO _selectedYear;
        private Agg_DropDownVariantDTO _selectedVariant;

        public Agg_DropDownMakeDTO SelectedMake
        {
            get => _selectedMake;
            set => SetProperty(ref _selectedMake, value);
        }

        public Agg_DropDownModelDTO SelectedModel
        {
            get => _selectedModel;
            set => SetProperty(ref _selectedModel, value);
        }

        public Agg_DropDownYORegisDTO SelectedYear
        {
            get => _selectedYear;
            set => SetProperty(ref _selectedYear, value);
        }

        public Agg_DropDownVariantDTO SelectedVariant
        {
            get => _selectedVariant;
            set => SetProperty(ref _selectedVariant, value);
        }


        public ObservableCollection<PV_OpenMarketDTO> StateListOpenMarket
        {
            get => _OpenMarketDTOs;
            private set => SetProperty(ref _OpenMarketDTOs, value);
        }
        public ObservableCollection<PV_AggregatorDTO> StateListAgreegator
        {
            get => _AggregatorDTOs;
            private set => SetProperty(ref _AggregatorDTOs, value);
        }
        public ObservableCollection<Agg_DropDownMakeDTO> StateListMake
        {
            get => _makeList;
            private set => SetProperty(ref _makeList, value);
        }

        public ObservableCollection<Agg_DropDownModelDTO> StateListModel
        {
            get => _modelList;
            private set => SetProperty(ref _modelList, value);
        }

        public ObservableCollection<Agg_DropDownVariantDTO> StateListVariant
        {
            get => _variantList;
            private set => SetProperty(ref _variantList, value);
        }

        public ObservableCollection<Agg_DropDownYORegisDTO> StateListYearOFList
        {
            get => _yearOfRegServiceList;
            private set => SetProperty(ref _yearOfRegServiceList, value);
        }

        private ObservableCollection<PV_NewCarDealerDTO> _dueCustomer;

        public ObservableCollection<PV_NewCarDealerDTO> StateListNewCardDealer
        {
            get => _dueCustomer;
            set => SetProperty(ref _dueCustomer, value);
        }

        public FullAggragatorViewModel(
            IFullAggragatorService aggService)
        {
            _aggService = aggService ?? throw new ArgumentNullException(nameof(aggService));

            StateListAgreegator = new ObservableCollection<PV_AggregatorDTO>();
            StateListOpenMarket = new ObservableCollection<PV_OpenMarketDTO>();
            StateListNewCardDealer = new ObservableCollection<PV_NewCarDealerDTO>(); // Initialize the collection in the constructor
            StateListMake = new ObservableCollection<Agg_DropDownMakeDTO>();
            StateListModel = new ObservableCollection<Agg_DropDownModelDTO>();
            StateListVariant = new ObservableCollection<Agg_DropDownVariantDTO>();
            StateListYearOFList = new ObservableCollection<Agg_DropDownYORegisDTO>();
        }

        private void ASetModelList(ObservableCollection<Agg_DropDownModelDTO> list)
{
    StateListModel = list;

    // Set the selected model if the list is not empty
    if (list.Count > 0)
    {
        SelectedModel = list[0]; // Set the default selection if needed
    }
}

        private async Task LoadDataAsync<T>(
            Func<Task<IEnumerable<T>>> getDataFunc,
            Action<ObservableCollection<T>> setCollectionAction,
            string typeName)
        {
            try
            {
                var data = await getDataFunc();

                switch (data)
                {
                    case IEnumerable<T> enumerableData:
                        setCollectionAction(new ObservableCollection<T>(enumerableData));
                        Console.WriteLine($"{typeName} details loaded successfully.");
                        break;

                    default:
                        Console.WriteLine($"Unexpected type: {data?.GetType().FullName}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading {typeName} data: {ex.Message}");
                // Consider logging or showing a user-friendly error message
                throw;
            }
        }

        public async Task LoadMakeDetailsAsync() =>
            await LoadDataAsync(_aggService.GetMakeData, SetMakeList, nameof(Agg_DropDownMakeDTO));

        public async Task LoadModelDetailsAsync() =>
            await LoadDataAsync(_aggService.GetModelData, SetModelList, nameof(Agg_DropDownModelDTO));

        public async Task LoadVariantDetailsAsync() =>
            await LoadDataAsync(_aggService.GetVariantData, SetVariantList, nameof(Agg_DropDownVariantDTO));

        public async Task LoadYearOfRegDetailsAsync() =>
            await LoadDataAsync(_aggService.GetYearOfRegData, SetYearOfRegList, nameof(Agg_DropDownYORegisDTO));

        public async Task<bool> LoadNewCarDealerDetails(PV_NewCarDealerDTO newCarDetails)
        {
            try
            {
                return await _aggService.PostNewCarDealerDetails(newCarDetails);
            }
            catch (Exception ex)
            {
                // Log the error using a logging framework or Debug.WriteLine
                Debug.WriteLine($"Error posting mobile number: {ex.Message}");
                // Rethrow the exception for consistency
                throw;
            }
        }

        public async Task<bool> LoadAggregatorDetails(PV_AggregatorDTO aggregator)
        {
            try
            {
                return await _aggService.PostAggragatorDetails(aggregator);
            }
            catch (Exception ex)
            {
                // Log the error using a logging framework or Debug.WriteLine
                Debug.WriteLine($"Error posting mobile number: {ex.Message}");
                // Rethrow the exception for consistency
                throw;
            }
        }

        public async Task<bool> LoadOpenMarketDetails(PV_OpenMarketDTO openMarket)
        {
            try
            {
                return await _aggService.PostOpenMarketDetails(openMarket);
            }
            catch (Exception ex)
            {
                // Log the error using a logging framework or Debug.WriteLine
                Debug.WriteLine($"Error posting mobile number: {ex.Message}");
                // Rethrow the exception for consistency
                throw;
            }
        }

        private void SetMakeList(ObservableCollection<Agg_DropDownMakeDTO> list) => StateListMake = list;

        private void SetModelList(ObservableCollection<Agg_DropDownModelDTO> list) => StateListModel = list;

        private void SetVariantList(ObservableCollection<Agg_DropDownVariantDTO> list) => StateListVariant = list;

        private void SetYearOfRegList(ObservableCollection<Agg_DropDownYORegisDTO> list) => StateListYearOFList = list;
    }
}
