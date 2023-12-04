//using Microsoft.Maui.Controls;
//using MyApp.Models;  // Make sure to include the Models namespace
//using MyApp.Service;
//using MyApp.ViewModel;
//using System;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace MyApp.View.Login
//{
//    public partial class BasicDetailView : ContentPage
//    {
//        private readonly BasicDetailsViewModel _viewModel;  // Change to BasicDetailsViewModel

//        public BasicDetailView()
//        {
//            InitializeComponent();

//            // Create an instance of BasicDetailsService and pass it to the BasicDetailsViewModel constructor
//            IBasicDetailsService basicDetailsService = new BasicDetailsService(new HttpClient());
//            _viewModel = new BasicDetailsViewModel(basicDetailsService);
//            BindingContext = _viewModel;
//        }

//        protected override async void OnAppearing()
//        {
//            base.OnAppearing();
//            await LoadData();
//        }

//        private async Task LoadData()
//        {
//            // Load additional data using the BasicDetailsViewModel (if needed)
//        }

//        private async void Button_Clicked(object sender, EventArgs e)
//        {
//            // Example: Create a BasicDetailsDTO and call the PostUserDetailsAsync method
//            BasicDetailsDTO userDetails = new BasicDetailsDTO
//            {
//                UserName = Entername.Text,
//                UserEmail = EmailId.Text,
//             //   StateId = (_viewModel.StateList[StatePicker.SelectedIndex]).StateId,
//                StatusId = 2
//            };

//            bool result = await _viewModel.PostUserDetailsAsync(userDetails);

//            // Handle the result as needed (e.g., show a message to the user)
//            if (result)
//            {
//                // Success
//                await DisplayAlert("Success", "User details posted successfully", "OK");
//            }
//            else
//            {
//                // Failure
//                await DisplayAlert("Error", "Failed to post user details", "OK");
//            }
//        }

//    }
//}



using Microsoft.Maui.Controls;
using MyApp.Service;
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
