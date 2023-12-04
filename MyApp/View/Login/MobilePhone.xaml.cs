//using MyApp.Service;
//using MyApp.ViewModel;

//namespace MyApp.View.Login
//{
//    public partial class MobilePhone : ContentPage
//    {
//        private readonly LoginUserPhoneViewModel _viewModel;
//        private string enteredPhoneNumber;

//        public MobilePhone()
//        {
//            InitializeComponent();
//            _viewModel = new LoginUserPhoneViewModel(new LoginUserPhoneServicecs(new HttpClient())); // Provide necessary dependencies here
//            BindingContext = _viewModel;
//        }

//        protected override async void OnAppearing()
//        {
//            base.OnAppearing();
//            await LoadData();
//        }

//        private async Task LoadData()
//        {
//            await _viewModel.LoadLoginDetails();
//        }

//        private void SendOTP_Clicked(object sender, EventArgs e)
//        {
//            // Get the entered phone number
//            enteredPhoneNumber = entryMobileNumber.Text;

//            // Check if the entered number is in the list from _viewModel
//            if (_viewModel.DueCustomer.Any(item => item.PhoneNumber == enteredPhoneNumber))
//            {
//                // If the entered number is in the list, navigate to the EnterOtpPage
//                Shell.Current.GoToAsync(nameof(EnterOtpPage));
//            }
//            else
//            {
//                // Handle the case where the entered number is not in the list
//                DisplayAlert("Invalid Number", "Login Failed.", "OK");
//            }
//        }
//    }
//}


// xaml.cs

using MyApp.Service;
using MyApp.ViewModel;

namespace MyApp.View.Login
{
    public partial class MobilePhone : ContentPage
    {
        private readonly PostLoginViewModel _viewModel;
        private string enteredPhoneNumber;

        public MobilePhone()
        {
            InitializeComponent();
            _viewModel = new PostLoginViewModel(new PostLogInService(new HttpClient())); // Provide necessary dependencies here
            BindingContext = _viewModel;
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var enteredMobileNumber = entryMobileNumber.Text;

                // Call the ViewModel method to perform the login
                bool loginResult = await _viewModel.PostLoginAsync(enteredMobileNumber);

                if (loginResult)
                {
                    // Navigate to the next page on successful login
                    await Shell.Current.GoToAsync(nameof(EnterOtpPage));
                }
                else
                {
                    // Handle login failure
                    await DisplayAlert("Login Failed", "Invalid Phone Number", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

    }
}
