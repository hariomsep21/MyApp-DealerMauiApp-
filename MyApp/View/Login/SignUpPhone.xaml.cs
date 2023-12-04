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
            enteredPhoneNumber = signMobileNumber.Text;

            // Check if the entered number is in the list from _viewModel
            if (!_viewModel.DueCustomer.Any(item => item.PhoneNumber == enteredPhoneNumber))
            {
                try
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
                      await  DisplayAlert("API Error", "Failed to post mobile number.", "OK");
                    }
                }
                catch (Exception ex)
                {
                    // Handle other exceptions that might occur during API call
                  await  DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                }
            }
            else
            {
                // Handle the case where the entered number is already in the list
               await DisplayAlert("Invalid Number", "Number Already Used So Login Failed.", "OK");
            }

        }

    }
}

