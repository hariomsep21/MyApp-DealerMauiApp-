using MyApp.Service;
using MyApp.ViewModel;

namespace MyApp.View.Login
{
    public partial class SignUpPhone : ContentPage
    {
        private readonly SignUpViewModel _viewModel;
        private string enteredPhoneNumber;
        public SignUpPhone()
        {
            InitializeComponent();
            _viewModel = new SignUpViewModel(new SignUpService(new HttpClient())); // Provide necessary dependencies here
            BindingContext = _viewModel;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadData();
        }

        private async Task LoadData()
        {
            await _viewModel.LoadLoginDetailsAsync();
        }

        private async void SendOTP_Clicked(object sender, EventArgs e)
        {
            // Get the entered phone number
            string enteredPhoneNumber = signMobileNumber.Text;

            // Validate the length of the mobile number
            if (string.IsNullOrEmpty(enteredPhoneNumber) || enteredPhoneNumber.Length != 10)
            {
                // Show error message for an invalid mobile number
                await DisplayAlert("Invalid Mobile Number", "Please enter a valid mobile number (10 digits).", "OK");
                return; // Exit the method without proceeding with login
            }

            try
            {
                // Check if the entered number is in the list from _viewModel
                if (!_viewModel.DueCustomer.Any(item => item.PhoneNumber == enteredPhoneNumber))
                {
                    // If the entered number is not in the list, pass it as a parameter to the API
                    bool apiSuccess = await _viewModel.PostMobileNumberAsync(enteredPhoneNumber);

                    if (apiSuccess)
                    {
                        // After sending OTP and successful API response, navigate to the EnterOtpPage
                        await Shell.Current.GoToAsync(nameof(EnterOtpPageSign));
                    }
                    else
                    {
                        // Handle the case where the API response is not successful
                        await DisplayAlert("API Error", "Failed to post the mobile number.", "OK");
                    }
                }
                else
                {
                    // Handle the case where the entered number is already in the list
                    await DisplayAlert("Invalid Number", "Number already used, so login failed.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions that might occur during the API call
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }


    }
}

