



using Microsoft.Maui.Controls;
using MyApp.Service;
using MyApp.IService;
using MyApp.ViewModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp.View.Login
{
    public partial class BasicDetailView : ContentPage
    {
        private readonly DropDownStateViewModel _viewModel;

        public BasicDetailView()
        {
            InitializeComponent();

           // Create an instance of DropDownStateService and pass it to the DropDownStateViewModel constructor
            IDropDownStateService dropDownStateService = new DropDownStateService(new HttpClient());
            _viewModel = new DropDownStateViewModel(dropDownStateService);
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadData();
        }

        private async Task LoadData()
        {
         //   Load additional data using the DropDownStateViewModel
            await _viewModel.LoadStateDetails();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

          //  Handle button click if needed
        }
    }
}
